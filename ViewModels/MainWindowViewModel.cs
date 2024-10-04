namespace Avalonia.CoffeeShop.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

        public MainWindowViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider ?? throw new ArgumentNullException(nameof(customerDataProvider));
            Customers = new ObservableCollection<CustomerItemViewModel>();
            _ = LoadAsync();
        }

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
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
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }
    }
}