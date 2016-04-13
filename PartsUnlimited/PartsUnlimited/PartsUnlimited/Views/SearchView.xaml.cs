using PartsUnlimited.ViewModels;
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
        public SearchView()
        {
            InitializeComponent();

            BindingContext = new SearchViewModel();
        }
    }
}
