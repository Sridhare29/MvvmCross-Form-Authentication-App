using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Authmvvmcross.Core.ViewModels
{
    public class ProfileViewmodelList: MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;
        public ProfileViewmodelList(IMvxNavigationService navigationService)
        {
            var base64String = Xamarin.Essentials.SecureStorage.GetAsync("selectedImage").Result;
            ImageSourcess = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64String)));
            _username = Preferences.Get("Username", "");
            _email = Preferences.Get("email", "");
            _navigationService = navigationService;
        }

        private IMvxCommand _logoutCommand;

        public IMvxCommand LogoutCommand
            {
                get
                {
                _logoutCommand = _logoutCommand ?? new MvxCommand(DoLogout);
                    return _logoutCommand;
                }
            }


        private  void DoLogout()
        {
             _navigationService.Navigate<LoginViewModel>();
        }


        private IMvxCommand _navigateCommand;
        public IMvxCommand NavigateCommands
        {
            get
            {
                _navigateCommand = _navigateCommand ?? new MvxCommand(() =>
                {
                    
                        _navigationService.Navigate(typeof(ProfileEditViewModel));
                  
                        Console.WriteLine("not initialized.");
                  
                });
                return _navigateCommand;
            }
        }

        private ImageSource _imageSource;
        public ImageSource ImageSourcess
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }





        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _firstname;
        public string Firstname
        {

            get => _firstname;
            set => SetProperty(ref _firstname, value);

        }
        private string _lastname;
        public string Lastname
        {

            get => _lastname;
            set => SetProperty(ref _lastname, value);

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
        private string _cpassword;
        internal ImageSource ImageSource;

        public string ConfirmPassword
        {
            get => _cpassword;
            set => SetProperty(ref _cpassword, value);

        }





    }
}
