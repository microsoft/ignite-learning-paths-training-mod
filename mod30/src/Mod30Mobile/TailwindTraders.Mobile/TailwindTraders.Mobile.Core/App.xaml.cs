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
            SetupPushNotifications();

            AppCenter.LogLevel = LogLevel.Verbose;

            // Handle when your app starts
            AppCenter.Start($"ios={AppCenterConstants.iOSAppSecret};" +
                  $"android={AppCenterConstants.AndroidAppSecret}",
                  typeof(Analytics), typeof(Crashes), typeof(Push), typeof(Distribute));
            
            Analytics.TrackEvent("Phoning Home");
           
            // Check to see if app crashed during last run
            if (await Crashes.HasCrashedInLastSessionAsync())
            {
                var report = await Crashes.GetLastSessionCrashReportAsync();

                var crashLastSessionEx = new Exception("Crash on last session");
                var lastSessionCrashDict = new Dictionary<string, string>
                {
                    { "RecoverFromCrash", "true" },
                    { "StackTrace", report.StackTrace }
                };

                Crashes.TrackError(crashLastSessionEx, lastSessionCrashDict);
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

        private void SetupPushNotifications()
        {
            if (!AppCenter.Configured)
            {                
                Push.PushNotificationReceived += async (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    var analyticsData = new Dictionary<string, string>();
                    
                    analyticsData.Add("title", e.Title);
                    analyticsData.Add("message", e.Message);

                    // Track that notification received
                    Analytics.TrackEvent("Push Received", analyticsData);

                    if (!string.IsNullOrEmpty(e.Title))
                    {
                        await Shell.Current.DisplayAlert(e.Title, e.Message, "OK");
                    }

                };
            }

        }
    }
}
