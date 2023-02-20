using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authmvvmcross.Core.DataService;
using Authmvvmcross.Core.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Authmvvmcross.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowView : MvxContentPage<DetailsViewModel>
    {
        public ShowView()
        {
            InitializeComponent();
       //var viewModel = new DetailsViewModel(new DatabaseService());
           // BindingContext = viewModel;

        }
    }
}

