using PartsUnlimited.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PartsUnlimited.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       
       

        public static ObservableCollection<Product> ProductStore { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        public double Total
        {
            get
            {
                if (Products != null)
                {
                    return Products.Sum(x => x.Price); 
                }

                return 0.0;
            }
        }

        public async Task Update()
        {
            if (ProductStore != null)
            {
                Products = new ObservableCollection<Product>(ProductStore.ToList()); 
            }

            RaisePropertyChanged("Total");
            RaisePropertyChanged("Products");
        }
    }
}
