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
    public class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchViewModel()
        {
            Items = new ObservableCollection<string>();
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

                if (_searchText.Length > 2)
                {
                    Search(); 
                }
            }
        }

        private void Search()
        {
            Items.Clear();

            foreach (var item in _data.Where(x => x.Contains(_searchText)).ToList())
            {
                Items.Add(item);
            };
        }

        public ObservableCollection<string> Items { get; set; }

        private List<string> _data = new List<string>()
        {
            "aluminiumfälg 14\"", "plåtfälg 14\"", "aluminiumfälg 14\"","aluminiumfälg 15\"","aluminiumfälg 16\"", "plåtfälg 15\"", "plåtfälg 16\"", "plåtfälg 17\""
        };
    }
}
