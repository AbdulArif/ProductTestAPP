using ProductTestAPP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProductTestAPP.Models;

namespace ProductTestAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditOrDeleteProductPage : ContentPage
    {
    
      public EditOrDeleteProductPage(Products product)
        {
            InitializeComponent();
            var editProductViewModel = new EditProductViewModel();

            editProductViewModel.Product = product;

            BindingContext = editProductViewModel;
        }
    }
}