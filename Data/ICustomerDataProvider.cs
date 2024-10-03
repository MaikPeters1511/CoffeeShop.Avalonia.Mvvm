using Customer = Avalonia.CoffeeShop.Models.Customer;

namespace Avalonia.CoffeeShop.Data;

public interface ICustomerDataProvider
{
    Task<IEnumerable<Customer>?> GetAllAsync();
}