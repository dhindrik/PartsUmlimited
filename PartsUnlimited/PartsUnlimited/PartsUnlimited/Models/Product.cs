using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PartsUnlimited.Models
{
    public class Product
    {
        public Product(string title, double price, string image, ICommand buy)
        {
            Title = title;
            Price = price;
            Image = image;
            Buy = buy;
        }

        public string Image { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public ICommand Buy { get; set; }
    }
}
