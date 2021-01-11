using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ProductTestAPP.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProductTestAPP.Models.Views;
using ProductTestAPP.Helpers;

namespace ProductTestAPP.Services
{
    internal class ApiServices
    {
        // RegisterUser
        #region
        public async Task<bool> RegisterUserAsync(
            string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                Constants.BaseApiAddress + "api/Account/Register", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        
        #endregion
        //Login User
        #region
        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, Constants.BaseApiAddress + "Token");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            var accessToken = jwtDynamic.Value<string>("access_token");

            Settings.AccessTokenExpirationDate = accessTokenExpiration;

            Debug.WriteLine(accessTokenExpiration);

            Debug.WriteLine(content);
            Debug.WriteLine("accessToken"+ accessToken);
            

            return accessToken;
        }
        #endregion
        //Get ALL products 
        #region
        public async Task<List<Products>> GetProductsAsync(string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "Product/GetProducts");

            var prods = JsonConvert.DeserializeObject<List<Products>>(json);

            return prods;
        }
        #endregion
        //Add Product Details
        #region
        public async Task PostProductAsync(Products product, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BaseApiAddress + "Product/PostProducts", content);
        }
        #endregion
        //Update Product Details
        #region
        public async Task PutProductAsync(Products product, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PutAsync(
                Constants.BaseApiAddress + "Product/PutProducts?Id=" + product.Id, content);
        }
        #endregion
        //Delete Product
        #region
        public async Task DeleteProductAsync(int productId, string accessToken)
        {
            var client = new HttpClient();
             client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            productId = 15;
             var response = await client.DeleteAsync(
                Constants.BaseApiAddress + "Product/DeleteProducts?id=" + productId);
        }
        #endregion
        // Search Product by Id
        #region 
        public async Task<List<Products>> SearchProductAsync(string keyword, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(
               Constants.BaseApiAddress + "Product/GetProductById?ID=" + keyword);

            dynamic resp = JsonConvert.DeserializeObject(json);
            Products products = resp.ToObject<Products>();
            List<Products> productList = new List<Products>();
            productList.Add(products);

            return productList;
        }
        #endregion
    }
}
