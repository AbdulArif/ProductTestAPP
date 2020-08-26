using Newtonsoft.Json;
using ProductTestAPP.Models;
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
            GetProducts();
        }

        private async void GetProducts()
        {
            HttpClient client = new HttpClient();
            //var response = await client.GetStringAsync("https://localhost:44342/Product/GetProducts");
            // var response = await client.GetStringAsync("http://localhost:56910/Product/GetProducts");
            //var response = await client.GetStringAsync("http://45.64.225.33:56910/Product/GetProducts");
            //var response = await client.GetStringAsync("http://192.168.0.101:56910/Product/GetProducts");
            var response = await client.GetStringAsync("http://192.168.43.196:45457/Product/GetProducts");
        
            var products = JsonConvert.DeserializeObject<List<Products>>(response);
            ProductListView.ItemsSource = products;
        }
    }
}
