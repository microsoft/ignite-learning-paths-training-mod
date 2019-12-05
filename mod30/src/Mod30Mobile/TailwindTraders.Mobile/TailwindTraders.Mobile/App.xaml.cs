using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TailwindTraders.Mobile.Services;
using TailwindTraders.Mobile.Views;
using MonkeyCache.SQLite;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using TailwindTraders.Mobile.Helpers;
using System.Collections.Generic;
using Microsoft.AppCenter.Push;
using Xamarin.Essentials;
using Plugin.Toasts;
using Plugin.XSnack;
using System.Threading.Tasks;
using Microsoft.AppCenter.Distribute;

namespace TailwindTraders.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = "tailwinddata";

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ProductCategoryDataStore>();
            DependencyService.Register<WishlistDataStore>();

            MainPage = new AppShell();
        }

        protected async override void OnStart()
        {
            await SetupPushNotifications();

            // Handle when your app starts
            AppCenter.Start($"ios={AppCenterConstants.iOSAppSecret};" +
                  $"android={AppCenterConstants.AndroidAppSecret}",
                  typeof(Analytics), typeof(Crashes), typeof(Push), typeof(Distribute));
           
            // Check to see if app crashed during last run
            if (await Crashes.HasCrashedInLastSessionAsync())
            {
                var report = await Crashes.GetLastSessionCrashReportAsync();

                Crashes.TrackError(new Exception(report.StackTrace), new Dictionary<string, string> { { "RecoverFromCrash", "true" } });
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private async Task SetupPushNotifications()
        {
            if (!AppCenter.Configured)
            {
                var isEnabled = await Push.IsEnabledAsync();

                if (!isEnabled)
                {
                    await Push.SetEnabledAsync(true);
                    isEnabled = await Push.IsEnabledAsync();
                }

                if (!isEnabled)
                    Analytics.TrackEvent("Issues with enabling push");

                Push.PushNotificationReceived += async (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    var analyticsData = new Dictionary<string, string>();

                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";

                            analyticsData.Add(key, e.CustomData[key]);
                        }
                    }

                    analyticsData.Add("title", e.Title);
                    analyticsData.Add("message", e.Message);

                    // Track that notification received
                    Analytics.TrackEvent("Push Received", analyticsData);

                    var snack = DependencyService.Get<IXSnack>();
                    await snack.ShowMessageAsync(e.Title);                   
                };
            }

        }
    }
}
