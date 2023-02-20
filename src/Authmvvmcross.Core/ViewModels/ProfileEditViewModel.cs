using System;
using System.Collections.Generic;
using System.Text;
using AuthenticationApp.Model;
using ImageCircle.Forms.Plugin.Abstractions;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using PermissionStatus = Plugin.Permissions.Abstractions.PermissionStatus;
using Xamarin.Forms;
using System.IO;
using SQLite;
using Authmvvmcross.Core.Model;
using MvvmCross;

namespace Authmvvmcross.Core.ViewModels
{
   public class ProfileEditViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;


        public ProfileEditViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _username = Preferences.Get("Username", "");
            _email = Preferences.Get("email", "");
            _password = Preferences.Get("password", "");
            RetrieveImage();

            //  imageString = Preferences.Get("selectedImage", "");
            //    Xamarin.Essentials.SecureStorage.SetAsync("selectedImage", imageString);


        }





        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        private string _email;
        public string Email
        {

            get => _email;
            set => SetProperty(ref _email, value);

        }

        private string _password;
        public string Password
        {

            get => _password;
            set => SetProperty(ref _password, value);

        }


        private IMvxCommand _saveDetail;

        public IMvxCommand SaveDetail
        {
            get
            {
                _saveDetail = _saveDetail ?? new MvxCommand(saveprofile);
                return _saveDetail;
            }
        }
        private MediaFile selectedImageFile;


        private async void saveprofile()
        {
            Preferences.Set("Username", _username);
            Preferences.Set("email", _email);
            Preferences.Set("password", _password);
            Console.WriteLine("Clicked");

            // Preferences.Set("selectedImage", imageString);
            // Xamarin.Essentials.SecureStorage.GetAsync("selectedImage");

            RetrieveImage();
//            string base64String = Preferences.Get("selectedImage"," ");


            Console.WriteLine("Updated");
            _navigationService.Navigate<ProfileViewmodelList>();

        }





        private User _item;
        private ImageSource _imageSource;

        public ImageSource ImageSources
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        private CircleImage _selectedImage;
        public CircleImage selectedImage
        {
            get { return _selectedImage; }
            set { SetProperty(ref _selectedImage, value); }
        }

        private MvxCommand _chooseImageCommand;
        private string imageString;
        private string stream;

        public MvxCommand ChooseImageCommand
        {
            get
            {
                _chooseImageCommand = _chooseImageCommand ?? new MvxCommand(ChooseImage);
                return _chooseImageCommand;
            }
        }

        public byte[] ImageData { get; private set; }

        private async void ChooseImage()
        {
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                storageStatus = results[Permission.Storage];
            }

            if (storageStatus != PermissionStatus.Granted)
            {
                Console.WriteLine("Storage permission not granted");
                return;
            }


            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                Console.WriteLine("Not Supported");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small

            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);
            if (selectedImageFile == null)
            {
                Console.WriteLine("Error");
                return;
            }

            ImageSources = ImageSource.FromStream(() => selectedImageFile.GetStream());

            using (var stream = selectedImageFile.GetStream())
            {
                var data = new byte[stream.Length];
                stream.Read(data, 0, (int)stream.Length);
                var base64String = Convert.ToBase64String(data);
                await Xamarin.Essentials.SecureStorage.SetAsync("selectedImage", base64String);
            }


        }

        private void RetrieveImage()
        {
            if (Xamarin.Essentials.SecureStorage.GetAsync("selectedImage").Result == null)
            {
                return;
            }
            var base64String = Xamarin.Essentials.SecureStorage.GetAsync("selectedImage").Result;
            var imageBytes = Convert.FromBase64String(base64String);
            ImageSources = ImageSource.FromStream(() => new MemoryStream(imageBytes));

        }



    }
}
