using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Authmvvmcross.Core.ViewModels.Home;
using Authmvvmcross.Core.ViewModels;
using Plugin.Media;

namespace Authmvvmcross.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            CrossMedia.Current.Initialize();

            RegisterAppStart<LoginViewModel>();
        }
    }
}
