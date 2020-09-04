using ProductTestAPP.Services;
using System.Windows.Input;
using Xamarin.Forms;
using ProductTestAPP.Models;
using ProductTestAPP.Helpers;

namespace ProductTestAPP.ViewModels
{
    public class LoginViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = await _apiServices.LoginAsync(Username, Password);

                    Settings.AccessToken = accesstoken;
                });
            }
        }

        public LoginViewModel()
        {
            Username = Settings.Username;
            Password = Settings.Password;
        }
    }
}
