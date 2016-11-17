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
        public void SearchAndBuy()
        {
            app.Tap(x => x.Id("search_src_text"));
            app.Screenshot("Tapped on view with class: SearchView$SearchAutoComplete marked: Search query");
            app.EnterText(x => x.Id("search_src_text"), "alu");
            app.Tap(x => x.Text("Aluminum rim 14\""));
            app.Screenshot("Tapped on view with class: FormsTextView");
            app.Tap(x => x.Text("Buy"));
            app.Screenshot("Tapped on view with class: Button");
            app.Tap(x => x.ClassFull("com.android.internal.widget.ScrollingTabContainerView$TabView").Index(1));
            app.Screenshot("Tapped on view with class: ScrollingTabContainerView$TabView");
            app.Tap(x => x.Text("Search"));
            app.Screenshot("Tapped on view with class: TextView");
            app.Tap(x => x.Text("Buy").Index(2));
            app.Screenshot("Tapped on view with class: Button");
            app.Tap(x => x.ClassFull("com.android.internal.widget.ScrollingTabContainerView$TabView").Index(1));
            app.Screenshot("Tapped on view with class: ScrollingTabContainerView$TabView");
           
        }

        [Test]
        public void NewTest()
        {
            app.Tap(x => x.ClassFull("com.android.internal.widget.ScrollingTabContainerView$TabView").Index(1));
            app.Tap(x => x.Text("Search"));
            app.Tap(x => x.Id("search_src_text"));
            app.EnterText(x => x.Id("search_src_text"), "steel");
            app.Tap(x => x.Text("Buy"));
            app.Tap(x => x.Text("Buy").Index(1));
        }

        [Test]
        public void DemoTest()
        {
            app.Repl();

            app.Tap(x => x.Marked("search_bar"));
            app.Screenshot("First page");
        }


    }
}


