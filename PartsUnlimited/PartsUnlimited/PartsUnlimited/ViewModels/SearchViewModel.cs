using PartsUnlimited.Models;
using PartsUnlimited.Views;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PartsUnlimited.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public SearchViewModel()
        {
            Items = new ObservableCollection<Product>(_data);
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                RaisePropertyChanged();

                if (_searchText != null && _searchText.Length > 2)
                {
                    Search(); 
                }
            }
        }

        private void Search()
        {
            Items.Clear();

            foreach (var item in _data.Where(x => x.Title.ToLower().Contains(_searchText.ToLower())).ToList())
            {
                Items.Add(item);
            };
        }

        public ObservableCollection<Product> Items { get; set; }

        private List<Product> _data = new List<Product>()
        {
            new Product("Aluminum rim 14\"",110,"http://www.scstyling.com/pub_images/large/Rondell058.jpg", Buy),
            new Product("Steel rim 14\"", 60,"http://www.falgproffset.se/500px/steel-7475.jpg", Buy),
            new Product("Aluminum rim 15\"",110,"http://www.scstyling.com/pub_images/large/Rondell058.jpg", Buy),
            new Product("Aluminum rim 16\"",110,"http://www.scstyling.com/pub_images/large/Rondell058.jpg", Buy),
            new Product("Aluminum rim 17\"",110,"http://www.scstyling.com/pub_images/large/Rondell058.jpg", Buy),
            new Product("Steel rim 15\"", 60,"http://www.falgproffset.se/500px/steel-7475.jpg", Buy),
            new Product("Steel rim 16\"", 60,"http://www.falgproffset.se/500px/steel-7475.jpg", Buy),
            new Product("Steel rim 17\"", 60,"http://www.falgproffset.se/500px/steel-7475.jpg", Buy),
        };

        public ICommand ShowMap
        {
            get
            {
                return new Command(() => {
                    Navigation.PushAsync(new MapView());
                });
            }
        }

        public static ICommand Buy
        {
            get
            {
                return new Command<Product>((product) => {
                    if(CartViewModel.ProductStore == null)
                    {
                        CartViewModel.ProductStore = new ObservableCollection<Product>();
                    }

                    CartViewModel.ProductStore.Add(product);

                    if(Notify != null)
                    {
                        Notify(string.Format("{0} added to the cart", product.Title));
                    }

                    
                });
            }
        }

        public static Action<string> Notify { get; set; }


    }
}
