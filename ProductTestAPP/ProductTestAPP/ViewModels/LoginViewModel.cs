using ProductTestAPP.Services;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ProductTestAPP.Models;

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

                    //Settings.AccessToken = accesstoken;
                });
            }
        }

        public LoginViewModel()
        {
            RegisterBindingModel registerBindingModel = new RegisterBindingModel();
            registerBindingModel.Email = Username;
            registerBindingModel.Password = Password;
            //Username = Settings.Username;
            // Password = Settings.Password;
        }
    }
}
