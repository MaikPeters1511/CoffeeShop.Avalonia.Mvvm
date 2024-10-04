namespace Avalonia.CoffeeShop.ViewModels
{
    public class CustomerItemViewModel : ViewModelBase
    {
        public Customer Customer { get; }

        public CustomerItemViewModel(Customer customer)
        {
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public string? FirstName => Customer.FirstName;
    }
}