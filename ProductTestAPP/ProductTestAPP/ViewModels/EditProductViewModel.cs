using ProductTestAPP.Helpers;
using ProductTestAPP.Models;
using ProductTestAPP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProductTestAPP.ViewModels
{
    public class EditProductViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        public Products Product { get; set; }

        public ICommand PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _apiServices.PutProductAsync(Product, Settings.AccessToken);
                });
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var PId = 5;
                    await _apiServices.DeleteProductAsync(PId, Settings.AccessToken);
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
