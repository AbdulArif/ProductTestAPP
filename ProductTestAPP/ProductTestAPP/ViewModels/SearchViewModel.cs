using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ProductTestAPP.Helpers;
using ProductTestAPP.Models;
using ProductTestAPP.Services;
using Xamarin.Forms;

namespace ProductTestAPP.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        private List<Products> _products;

        public List<Products> ProductsList
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public string Keyword { get; set; }

        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    ProductsList = await _apiServices.SearchProductAsync(Keyword, Settings.AccessToken);
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
