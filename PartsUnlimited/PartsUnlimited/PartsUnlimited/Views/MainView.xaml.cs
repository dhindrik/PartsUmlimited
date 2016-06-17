using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PartsUnlimited.Views
{
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();

            var search = new NavigationPage(new SearchView());
            search.Title = "Search";
            search.Icon = "search.png";
            search.BarBackgroundColor = Color.FromHex("#EE5F56");
            search.BarTextColor = Color.White;
            

            

            var cart = new NavigationPage(new CartView());
            cart.Title = "Cart";
            cart.Icon = "cart.png";
            cart.BarBackgroundColor = Color.FromHex("#EE5F56");
            cart.BarTextColor = Color.White;

            var stores = new NavigationPage(new MapView());
            stores.Title = "Stores";
            stores.Icon = "stores.png";
            stores.BarBackgroundColor = Color.FromHex("#EE5F56");
            stores.BarTextColor = Color.White;

            Children.Add(search);
            Children.Add(cart);
            Children.Add(stores);
        }
    }
}
