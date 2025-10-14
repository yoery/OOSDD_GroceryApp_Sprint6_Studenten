using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Microsoft.Maui.Controls;
using Grocery.Core.Models;


namespace Grocery.App.ViewModels
{
    public class NewProductViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        private string _name = string.Empty;
        private decimal _price;
        private int _stock;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public int Stock
        {
            get => _stock;
            set { _stock = value; OnPropertyChanged(); }
        }

        public ICommand AddProductCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public NewProductViewModel(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
            AddProductCommand = new Command(OnAddProduct, CanAddProduct);
        }

        private bool CanAddProduct()
        {
            // Tijdelijk: iedereen is admin
            return true;
        }

        private void OnAddProduct()
        {
            // Zorg dat de juiste constructor wordt gebruikt en converteer indien nodig
            var newProduct = new Product(0, Name, Stock, default, Price);

            var addedProduct = _productService.Add(newProduct);

            // Stuur bericht naar ProductViewModel
            MessagingCenter.Send(this, "ProductAdded", addedProduct);

            // Velden leegmaken etc.
            Name = string.Empty;
            Price = 0;
            Stock = 0;
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public interface IUserService
    {
        User CurrentUser { get; set; }
    }

    public class User
    {
        public string Role { get; set; } = string.Empty;
    }
}
