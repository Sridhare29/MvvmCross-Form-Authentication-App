using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Forms.Platforms.Android.Views;
using Authmvvmcross.Core.ViewModels.Main;
using Plugin.Media;
using ImageCircle.Forms.Plugin.Droid;
using MvvmCross.ViewModels;
using MvvmCross.Platforms.Android;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using Authmvvmcross.Core;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Authmvvmcross.Droid
{
    [Activity(
        Theme = "@style/AppTheme")]

    public class MainActivity : MvxFormsAppCompatActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CrossMedia.Current.Initialize();

            

        }
    }
}
