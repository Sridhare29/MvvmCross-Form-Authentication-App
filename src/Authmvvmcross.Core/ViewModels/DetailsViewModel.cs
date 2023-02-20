using System;
using System.Collections.Generic;
using System.Text;
using Authmvvmcross.Core.DataService;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Essentials;

namespace Authmvvmcross.Core.ViewModels
{
    public class DetailsViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public DetailsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;


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
        public string ConfirmPassword
        {
                get => _cpassword;
                set => SetProperty(ref _cpassword, value);
            
        }


       

        public DetailsViewModel()
        {
            // Get the username from Xamarin.Essentials Preferences
            _username = Preferences.Get("Username", "");
            _firstname = Preferences.Get("firstname", "");
            _lastname = Preferences.Get("lastname", "");
            _email = Preferences.Get("email", "");
            _password = Preferences.Get("password", "");
            _cpassword = Preferences.Get("confirmpassword", "");
        }



    }


    }


