using ProductTestAPP.Models;
using ProductTestAPP.Models.Views;
using ProductTestAPP.Views;
using Xamarin.Forms;

namespace ProductTestAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new RegisterPage());
            //MainPage = new NavigationPage(new GetProducts());
            //MainPage = new NavigationPage(new EditOrDeleteProductPage());
            // MainPage = new NavigationPage(new AddProductPage());
            //MainPage = new NavigationPage(new SearchPage()); 
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
