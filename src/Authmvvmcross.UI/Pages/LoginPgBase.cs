using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;

namespace Authmvvmcross.UI.Pages
{
    [MvxContentPagePresentation(WrapInNavigationPage = true), XamlCompilation(XamlCompilationOptions.Compile), XamlFilePath("Pages\\LoginPg.xaml")]
    public class LoginPgBase
    {
    }
}