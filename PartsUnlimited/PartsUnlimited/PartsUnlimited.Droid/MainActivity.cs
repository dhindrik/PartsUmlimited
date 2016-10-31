using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Plugin.Toasts;

namespace PartsUnlimited.Droid
{
    [Activity(Label = "Parts Unlimited", Icon = "@drawable/sogeti", Theme ="@style/Sogeti", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            DependencyService.Register<ToastNotificatorImplementation>();
            ToastNotificatorImplementation.Init(this);

            Xamarin.FormsMaps.Init(this, bundle);
#if ENABLE_TEST_CLOUD
            Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };
#endif  
            ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));
        }
    }
}

