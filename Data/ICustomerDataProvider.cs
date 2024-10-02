namespace Avalonia.CoffeeShop.Data;

public interface ICustomerDataProvider
{
    Task<IEnumerable<Customer>?> GetAllAsync();
}