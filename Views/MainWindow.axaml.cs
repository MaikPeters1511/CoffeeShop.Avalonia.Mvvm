using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Styling;
using Avalonia.Threading;

namespace Avalonia.CoffeeShop.Views;

public partial class MainWindow : Window
{
    private DispatcherTimer? _timer;

    public MainWindow()
    {
        InitializeComponent();
        //DataContext =  MainWindowViewModel.Instance;
        StartClock();
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
        TimeBlock.Text = DateTime.Now.ToString("HH:mm:ss");
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