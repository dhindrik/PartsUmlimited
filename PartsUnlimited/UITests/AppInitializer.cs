using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
#if DEBUG
                return ConfigureApp
                    .Android.ApkFile(@"..\..\..\PartsUnlimited\PartsUnlimited.Droid\bin\Release\sogeti.demo.partsunlimited.apk")
                    .StartApp();
#endif

                return ConfigureApp
                    .Android
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

