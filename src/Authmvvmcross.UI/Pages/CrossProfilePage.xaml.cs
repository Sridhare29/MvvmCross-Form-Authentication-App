using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Authmvvmcross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Authmvvmcross.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrossProfilePage : MvxContentPage<ProfileEditViewModel>
    {
        private ProfileEditViewModel _profilePageViewModel;

        public CrossProfilePage()
        {
            InitializeComponent();

        }

        public CrossProfilePage(ProfileEditViewModel profilePageViewModel)
        {
            _profilePageViewModel = profilePageViewModel;
        }
    }
}
