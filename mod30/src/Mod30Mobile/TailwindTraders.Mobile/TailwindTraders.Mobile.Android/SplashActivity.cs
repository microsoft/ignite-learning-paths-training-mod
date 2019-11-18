using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TailwindTraders.Mobile.Droid
{
    [Activity(
        Label = "@string/appName",
        Icon = "@mipmap/icon",
        Theme = "@style/SplashTheme",
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = new Intent(this, typeof(MainActivity));
            if (Intent.Extras != null)
                intent.PutExtras(Intent.Extras); // copy push info from splash to main
            StartActivity(intent);
        }
    }
}