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
        public IServiceProvider ServiceProvider { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Registration for ICustomerDataProvider with its implementation
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>();
            return services.BuildServiceProvider();
        }

        public App()
        {
            ServiceProvider = ConfigureServices();
        }
    }
}