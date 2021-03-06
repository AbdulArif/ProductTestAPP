﻿using ProductTestAPP.Services;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ProductTestAPP.Models;
using ProductTestAPP.Helpers;

namespace ProductTestAPP.ViewModels
{
    public class RegisterViewModel
    {

        private readonly ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isRegistered = await _apiServices.RegisterUserAsync
                        (Username, Password, ConfirmPassword);

                    RegisterBindingModel registerBindingModel = new RegisterBindingModel();
                    registerBindingModel.Email = Username;
                    registerBindingModel.Password = Password;

                   Settings.Username = Username;
                   Settings.Password = Password;

                    if (isRegistered)
                    {
                        Message = "Success :)";
                    }
                    else
                    {
                        Message = "Please try again :(";
                    }
                });
            }
        }
    }
}
