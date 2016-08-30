using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    [TestFixture(Platform.iOS)]

    public class iOSTests
    {
        IApp app;
        Platform platform;

        public iOSTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

      
           [Test]
        public void SearchAndBuy()
        {
            
            app.Screenshot("Search");
            
            app.Tap(x => x.Text("Aluminum rim 14\""));
          
            app.Tap(x => x.Text("Buy"));
           
            app.Tap(x => x.Text("Cart"));
            app.Screenshot("Cart");
           
        }

    }
}


