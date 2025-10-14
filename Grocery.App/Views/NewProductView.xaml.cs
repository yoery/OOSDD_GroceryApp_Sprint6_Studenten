using System;
using Grocery.App.ViewModels;
using Grocery.Core.Interfaces.Services; // Add this for IProductService and IUserService
using Microsoft.Extensions.DependencyInjection; // Add this for GetService<T>()

namespace Grocery.App.Views
{
    public partial class NewProductView : ContentPage
    {
        public NewProductView()
        {
            InitializeComponent();
            var serviceProvider = ((App)Application.Current).Services; // Cast Application.Current to your App class
            BindingContext = new NewProductViewModel(
                serviceProvider.GetService<IProductService>(),
                serviceProvider.GetService<IUserService>()
            );
        }
    }
}
