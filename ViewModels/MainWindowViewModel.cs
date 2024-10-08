using Avalonia.CoffeeShop.Command;
namespace Avalonia.CoffeeShop.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase
{
    private readonly ICustomerDataProvider _customerDataProvider;
    private CustomerItemViewModel? _selectedCustomer;
    private string _text;
    public MainWindowViewModel(ICustomerDataProvider customerDataProvider)
    {
        _customerDataProvider = customerDataProvider ?? throw new ArgumentNullException(nameof(customerDataProvider));
        Customers = new ObservableCollection<CustomerItemViewModel>();
        _ = LoadAsync();
        AddCommand = new DelecateCommand(AddCustomer);
        DeleteCommand = new DelecateCommand(Delete, CanDelete);
    }

    public DelecateCommand AddCommand { get; }

    public DelecateCommand DeleteCommand { get; }

    public CustomerItemViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            if (_selectedCustomer != value)
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public string Text
    {
        get => _text;
        set
        {
            if (_text != value)
            {
                _text = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsTextEmpty));
            }
        }
    }

    public string Firstname => "Firstname";
    public string Lastname => "Lastname";

    public bool IsTextEmpty => string.IsNullOrEmpty(Text);
    public bool IsCustomerSelected => SelectedCustomer is not null;

    public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

    public async Task LoadAsync()
    {
        if (Customers.Any())
        {
            return;
        }

        var customers = await _customerDataProvider.GetAllAsync();
        if (customers != null)
        {
            foreach (var customer in customers)
            {
                Customers.Add(new CustomerItemViewModel(customer));
            }
        }
    }

    private void AddCustomer(object? parameter)
    {
        var customer = new Customer {FirstName = "New"};
        var viewModel = new CustomerItemViewModel(customer);
        Customers.Add(viewModel);
        SelectedCustomer = viewModel;
    }

    private void Delete(object? parameter)
    {
        if (SelectedCustomer is null)
        {
            return;
        }

        Customers.Remove(SelectedCustomer);
        SelectedCustomer = null;
    }

    private bool CanDelete(object? parameter) => SelectedCustomer is not null;
}

