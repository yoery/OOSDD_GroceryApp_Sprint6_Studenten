using Grocery.App.ViewModels;
using Grocery.App.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.App
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public App(LoginViewModel viewModel)
        {
            var serviceCollection = new ServiceCollection();
            // Register your services here, e.g.:
            // serviceCollection.AddSingleton<IProductService, ProductService>();
            // serviceCollection.AddSingleton<IUserService, UserService>();
            Services = serviceCollection.BuildServiceProvider();

            InitializeComponent();
            //MainPage = new AppShell();
            MainPage = new LoginView(viewModel);
        }
    }
}
