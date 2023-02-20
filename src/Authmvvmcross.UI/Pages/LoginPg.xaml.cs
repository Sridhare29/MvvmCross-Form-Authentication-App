using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authmvvmcross.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Authmvvmcross.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]

    public partial class LoginPg : MvxContentPage<LoginViewModel>
    {
        public LoginPg()
        {
            InitializeComponent();
        }   
    }
}
