using ProductTestAPP.Models;
using ProductTestAPP.Views;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProductTestAPP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class GetProducts : ContentPage
    {
        public GetProducts()
        {
            InitializeComponent();
           // GetProducts();
        }

        private async void Button_Delete(object sender, EventArgs e)
        {
              Products product= new Products();
                product.Id = 2;
                product.Name="prod6";
                product.Category = "cat13";
                product.Price = 500;
       await Navigation.PushAsync(new EditOrDeleteProductPage(product));
        }
    }
}
