using System.Collections.ObjectModel;
using Grocery.Core.Models;
using Grocery.Core.Interfaces.Services;
using Microsoft.Maui.Controls;

namespace Grocery.App.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; } = new();

        public ProductViewModel(IProductService productService)
        {
            var products = productService.GetAll();
            foreach (var product in products)
                Products.Add(product);

            // Subscribe to new product messages
            MessagingCenter.Subscribe<NewProductViewModel, Product>(this, "ProductAdded", (sender, product) =>
            {
                Products.Add(product);
            });
        }
    }
}
