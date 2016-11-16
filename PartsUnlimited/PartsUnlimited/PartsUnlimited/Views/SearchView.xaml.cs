using PartsUnlimited.ViewModels;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PartsUnlimited.Views
{
    public partial class SearchView : ContentPage
    {
        public SearchViewModel ViewModel { get { return BindingContext as SearchViewModel; } }
        public SearchView()
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "");

            ViewModel.Navigation = Navigation;

            SearchViewModel.Notify = (message) =>
            {
                var notificator = DependencyService.Get<IToastNotificator>();
                notificator.Notify(ToastNotificationType.Success, message, string.Empty, TimeSpan.FromSeconds(1), null, false);
            };
        }

        public void Product_Selected(object sender, EventArgs e)
        {
            List.SelectedItem = null;
        }
    }
}
