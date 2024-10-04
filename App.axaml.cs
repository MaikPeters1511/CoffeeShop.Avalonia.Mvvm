using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.CoffeeShop.ViewModels;
using Avalonia.CoffeeShop.Views;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;

namespace Avalonia.CoffeeShop
{
    public class App : Application
    {
        public IServiceProvider? ServiceProvider { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            ServiceProvider = ConfigureServices();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                try
                {
                    var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
                    desktop.MainWindow = mainWindow;
                }
                catch (Exception ex)
                {
                    // Handle exceptions if the required service is not found
                    Console.WriteLine("Error initializing MainWindow: " + ex.Message);
                    throw;
                }
            }

            base.OnFrameworkInitializationCompleted();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Ensure RealCustomerDataProvider is defined and referenced correctly
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}