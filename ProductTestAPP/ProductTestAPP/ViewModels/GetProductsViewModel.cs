using ProductTestAPP.Services;
using System.Windows.Input;
using Xamarin.Forms;
using ProductTestAPP.Models;
using ProductTestAPP.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ProductTestAPP.ViewModels
{
    public class GetProductsViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        private List<Products> _products;

        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }

        public List<Products> ProductListView
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetProductsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = Settings.AccessToken;
                    ProductListView = await _apiServices.GetProductsAsync(accessToken);
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = string.Empty;
                    Debug.WriteLine(Settings.Username);
                    Settings.Username = string.Empty;
                    Debug.WriteLine(Settings.Password);
                    Settings.Password = string.Empty;

                    // navigate to LoginPage
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
