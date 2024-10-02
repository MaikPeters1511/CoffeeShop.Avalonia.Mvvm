using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.CoffeeShop.ViewModels;
using Avalonia.CoffeeShop.Views;
using Avalonia.Styling;
using Avalonia.Threading;

namespace Avalonia.CoffeeShop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            this.RequestedThemeVariant = ThemeVariant.Dark;
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(new CustomerDataProvider()),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}