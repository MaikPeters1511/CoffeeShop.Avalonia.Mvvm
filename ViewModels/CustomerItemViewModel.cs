namespace Avalonia.CoffeeShop.ViewModels
{
    public class CustomerItemViewModel : ViewModelBase
    {
        public Customer Customer { get; }

        public CustomerItemViewModel(Customer customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public int Id
        {
            get => Customer.Id;
            set
            {
                if (Customer.Id != value)
                {
                    Customer.Id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? FirstName
        {
            get => Customer.FirstName;
            set
            {
                if (Customer.FirstName != value)
                {
                    Customer.FirstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? LastName
        {
            get => Customer.LastName;
            set
            {
                if (Customer.LastName != value)
                {
                    Customer.LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDeveloper
        {
            get => Customer.IsDeveloper;
            set
            {
                if (Customer.IsDeveloper != value)
                {
                    Customer.IsDeveloper = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}