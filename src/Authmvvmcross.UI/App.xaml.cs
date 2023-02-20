using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Authmvvmcross.UI.Pages;
using Plugin.Media;
using Xamarin.Forms;

namespace Authmvvmcross.UI
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new Register();

            CrossMedia.Current.Initialize();

            InitializeComponent();
        }
    }
}
