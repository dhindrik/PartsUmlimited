using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Plugin.Toasts;
using Xamarin.Forms;
using HockeyApp;

namespace PartsUnlimited.iOS
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
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("f5ec309128ea41d59857c180c967c9db");
            manager.StartManager();

            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
            LoadApplication(new App());

            DependencyService.Register<ToastNotificatorImplementation>(); 
            ToastNotificatorImplementation.Init();

            UITabBar.Appearance.TintColor = UIColor.Gray;
            UITabBar.Appearance.SelectedImageTintColor = UIColor.FromRGB(238, 95, 56);

            #if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
            #endif

            return base.FinishedLaunching(app, options);
        }
    }
}
