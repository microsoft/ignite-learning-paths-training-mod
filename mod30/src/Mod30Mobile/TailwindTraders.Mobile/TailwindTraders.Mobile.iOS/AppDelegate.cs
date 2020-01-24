using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Push;
using Plugin.XSnack;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            DependencyService.Register<IXSnack, XSnackImplementation>();

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();
                       
            LoadApplication(new App());

            UINavigationBar.Appearance.Translucent = false;
            UINavigationBar.Appearance.TintColor = UIColor.White;

            return base.FinishedLaunching(app, options);
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            Analytics.TrackEvent("iOS Registered - Remote Notifications");
            Push.RegisteredForRemoteNotifications(deviceToken);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            Analytics.TrackEvent("iOS FAILED - Remote Notifications");

            Push.FailedToRegisterForRemoteNotifications(error);
        }

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, System.Action<UIBackgroundFetchResult> completionHandler)
        {
            Analytics.TrackEvent("iOS Received - Remote Notifications");

            var result = Push.DidReceiveRemoteNotification(userInfo);
            if (result)
            {
                completionHandler(UIBackgroundFetchResult.NewData);
            }
            else
            {
                completionHandler(UIBackgroundFetchResult.NoData);
            }
        }
    }
}
