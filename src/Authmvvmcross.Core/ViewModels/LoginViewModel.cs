using System;
using System.Text.RegularExpressions;
using Authmvvmcross.Core.DataService;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Authmvvmcross.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public LoginViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        private string _username;
            private string _password;
            private IMvxCommand _loginCommand;
            public string Username
            {
                get => _username;
                set
                {
                    _username = value;
                    RaisePropertyChanged(nameof(Username));
                }
            }

            public string Password
            {
                get => _password;
                set
                {
                    _password = value;
                    RaisePropertyChanged(nameof(Password));
                }
            }


        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
//        public bool ErrorMessageVisible => !string.IsNullOrEmpty(ErrorMessage);


        //SignupagainCommand
        public IMvxCommand LoginCommand
            {
                get
                {
                    _loginCommand = _loginCommand ?? new MvxCommand(DoLogin);
                    return _loginCommand;
                }
            }

        private async void DoLogin()
        {
            var storedUsername = Preferences.Get("Username", "");
            var storedPassword = Preferences.Get("password", "");

            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "Username is required";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Password is required";
                return;
            }


            if (Username == storedUsername && Password == storedPassword)
            {
                Console.WriteLine("Success");
                await Application.Current.MainPage.DisplayAlert("Login Successfully", "", "Ok");

                await _navigationService.Navigate<ProfileViewmodelList>();
            }
            else
            {
                Console.WriteLine("Fail");
                ErrorMessage = "Incorrect Credentials";
                return;
                // Login failed
            }
            ErrorMessage = string.Empty;


        }


        private IMvxCommand _signupagainCommand;

        public IMvxCommand SignupagainCommand
        {
            get
            {
               _signupagainCommand = _signupagainCommand ?? new MvxCommand(DoSignupag);
                return _signupagainCommand;
            }
        }

        private async void DoSignupag()
        {
          

            await _navigationService.Navigate<SignupViewModel>();
        }

    }
}
