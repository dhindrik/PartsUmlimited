using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Tap(x => x.ClassFull("android.widget.SearchView$SearchAutoComplete").Id("search_src_text"));
            app.Screenshot("Tapped on view SearchView$SearchAutoComplete with ID: 'search_src_text'");
            app.EnterText(x => x.ClassFull("android.widget.SearchView$SearchAutoComplete").Id("search_src_text"), "plå");
            app.Screenshot("Entered 'plå' into view SearchView$SearchAutoComplete with ID: 'search_src_text'");
            app.Tap(x => x.Class("ImageView").Id("search_close_btn"));
            app.Screenshot("Tapped on view ImageView with ID: 'search_close_btn'");
        }
    }
}

