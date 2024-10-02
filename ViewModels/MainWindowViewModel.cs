namespace Avalonia.CoffeeShop.ViewModels;

public sealed class MainWindowViewModel(
    ICustomerDataProvider customerDataProvider,
    CustomerItemViewModel? selectedCustomer = null) : ViewModelBase
{
    private readonly ICustomerDataProvider _customerDataProvider =
        customerDataProvider ?? throw new ArgumentNullException(nameof(customerDataProvider));

    private CustomerItemViewModel? _selectedCustomer = selectedCustomer;


    public CustomerItemViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            if (_selectedCustomer != value)
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCustomerSelected));
            }
        }
    }

    public bool IsCustomerSelected => SelectedCustomer is not null;
    public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

    public async Task LoadAsync()
    {
        if (Customers.Any())
        {
            return;
        }

        var customers = await _customerDataProvider.GetAllAsync();
        if (customers is not null)
        {
            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }
    }
}