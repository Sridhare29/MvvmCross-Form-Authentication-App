using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using AuthenticationApp.Model;
using Authmvvmcross.Core.DataService;
using Authmvvmcross.Core.ViewModels.Home;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Authmvvmcross.Core.ViewModels
{
    public class SignupViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public SignupViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;


        }

        private IMvxCommand _signUpCommand;
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }
        private string _firstname;
        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                RaisePropertyChanged(nameof(Firstname));
            }
        }
        private string _lastname;
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                RaisePropertyChanged(nameof(Lastname));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        private string _cpassword;
        public string ConfirmPassword
        {
            get => _cpassword;
            set
            {
                _cpassword = value;
                RaisePropertyChanged(nameof(ConfirmPassword));
            }
        }


        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        //LoginaginCommand
        public IMvxCommand SignUpCommand
        {
            get
            {
                _signUpCommand = _signUpCommand ?? new MvxCommand(DoSignUp);
                return _signUpCommand;
            }
        }


        private async void DoSignUp()
        {
            Preferences.Set("Username", _username);
            Preferences.Set("firstname", _firstname);
            Preferences.Set("lastname", _lastname);
            Preferences.Set("email", _email);
            Preferences.Set("password", _password);
            Preferences.Set("confirmpassword", _cpassword);

            if (string.IsNullOrWhiteSpace(Username))
            {
                ErrorMessage = "Username is required";
                return;
            }

            if (string.IsNullOrWhiteSpace(Firstname))
            {
                ErrorMessage = "Firstname is required";
                return;
            }
            if (string.IsNullOrWhiteSpace(Lastname))
            {
                ErrorMessage = "Lastname is required";
                return;
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage = "Email is required";
                return;
            }

            if (!Regex.IsMatch(_email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {
                ErrorMessage = "Invalid Email";
                return;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Password is required";
                return;
            }
       
            if (!Regex.IsMatch(_password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"))
            {
                ErrorMessage = "Invalid Password!";
                return;
            }
            if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ErrorMessage = "ConfirmPassword is required";
                return;
                _password = string.Empty;

            }
            if (!string.Equals(_password, _cpassword))
            {
              
                ErrorMessage = "Password are not same";
                return;
                _password = string.Empty;
                _cpassword = string.Empty;

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Signup Successfully", "", "Ok");

                await _navigationService.Navigate<LoginViewModel>();
                Console.WriteLine("Succefully Signup");

            }
          ErrorMessage = string.Empty;

        }





    }
}

