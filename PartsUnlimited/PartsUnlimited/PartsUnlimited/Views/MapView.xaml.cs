using PartsUnlimited.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace PartsUnlimited.Views
{
    public partial class MapView : ContentPage
    {
        public MapView()
        {
            InitializeComponent();

            NavigationPage.SetBackButtonTitle(this, "");
        }


        private bool _hasPosition;

        private List<Store> _stores = new List<Store>()
        {
            new Store() {Name = "Kupolen", Latitude = 60.48429, Longitude = 15.41805 },
            new Store() {Name = "Norra backa", Latitude = 60.48030, Longitude = 15.42017 },
            new Store() {Name = "Borlänge Central", Latitude = 60.48291, Longitude = 15.42626 },
        };

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if(!_hasPosition)
            {
                var position = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync(10000);
                
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(60.48322, 15.40938), Distance.FromKilometers(3)));

                foreach(var store in _stores)
                {
                    var pin = new Pin()
                    {
                        Type = PinType.SearchResult,
                        Position = new Position(store.Latitude, store.Longitude),
                        Label = store.Name
                    };

                    Map.Pins.Add(pin);
                }


                _hasPosition = true;
            }

        }
        
    }
}
