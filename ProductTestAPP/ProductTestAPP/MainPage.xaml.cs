using Newtonsoft.Json;
using ProductTestAPP.Models;
using ProductTestAPP.Models.Views;
using ProductTestAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProductTestAPP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //GetProducts();
        }

        private async void Button_Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void Button_SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
        private async void Button_AddProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage());
        }
        //private async void Button_EditOrDeleteProductp(object sender, EventArgs e)
        //{
        //    Products products;
        //    await Navigation.PushAsync(new EditOrDeleteProductPage(products));
        //}
        private async void Button_SearchProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
        private async void Button_AllProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetProducts());
        }

        //private async void GetProducts()
        //{
        //    HttpClient client = new HttpClient();
        //    //var response = await client.GetStringAsync("http://192.168.0.102:45455/Product/GetProducts"); //it works
        //    var response = await client.GetStringAsync("http://productwebapi.azurewebsites.net/Product/GetProducts");


        //    var products = JsonConvert.DeserializeObject<List<Products>>(response);
        //    ProductListView.ItemsSource = products;
        //}
    }
}
