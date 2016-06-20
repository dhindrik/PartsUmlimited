using PartsUnlimited.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PartsUnlimited.Views
{
    public partial class CartView : ContentPage
    {
        private CartViewModel ViewModel { get { return BindingContext as CartViewModel; } }

        public CartView()
        {
            InitializeComponent();

            var button = new ToolbarItem()
            {
                Text = "Clear",

            };

            button.Clicked += Button_Clicked;

            ToolbarItems.Add(button);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            throw new Exception("You can not clear cart, you need to buy this!");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if(ViewModel != null)
            {
                await ViewModel.Update();
            }
        }

        public void Product_Selected(object sender, EventArgs e)
        {
            List.SelectedItem = null;
        }
    }
}
