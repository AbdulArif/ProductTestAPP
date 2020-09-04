using ProductTestAPP.Services;
using Xamarin.Forms;
using System.Windows.Input;
using ProductTestAPP.Helpers;
using ProductTestAPP.Models;
namespace ProductTestAPP.ViewModels
{
    public class AddProductViewModel
    {
        ApiServices _apiServices = new ApiServices();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }


        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var product = new Products
                    {
                        Name = Name,
                        Category = Category,
                        Price = (float)Price
                    };
                    await _apiServices.PostProductAsync(product, Settings.AccessToken);
                });
            }
        }
    }
}
