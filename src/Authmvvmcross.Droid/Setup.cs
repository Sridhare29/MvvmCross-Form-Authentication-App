using Android.App;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.Presenters;
using Serilog;
using Serilog.Extensions.Logging;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace Authmvvmcross.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }




    }
}
