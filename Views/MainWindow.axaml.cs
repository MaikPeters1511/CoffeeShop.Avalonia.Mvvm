using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Styling;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.CoffeeShop.ViewModels;

namespace Avalonia.CoffeeShop.Views;

public partial class MainWindow : Window
{
    private DispatcherTimer? _timer;
    private TextBlock? _timeBlock;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = (((App)Application.Current)).ServiceProvider.GetRequiredService<MainWindowViewModel>();
        StartClock();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        _timeBlock = this.FindControl<TextBlock>("TimeBlock");
    }

    private void StartClock()
    {
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(1)
        };
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (_timeBlock != null)
        {
            _timeBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }

    private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
    {
       ButtonAddCustomer.Content = "Customer Added";
    }

    private void OnToggleThemeClick(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Application.Current?.RequestedThemeVariant == ThemeVariant.Light)
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
        }
        else
        {
            Application.Current!.RequestedThemeVariant = ThemeVariant.Light;
        }
    }
}