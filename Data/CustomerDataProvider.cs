﻿using Customer = Avalonia.CoffeeShop.Models.Customer;

namespace Avalonia.CoffeeShop.Data;

public class CustomerDataProvider : ICustomerDataProvider
{
    public async Task<IEnumerable<Customer>?> GetAllAsync()
    {
        await Task.Delay(100); // Simulate a bit of server work

        return await Task.FromResult<IEnumerable<Customer>>(new List<Customer>
        {
            new Customer { Id = 1, FirstName = "Julia", LastName = "Developer", IsDeveloper = true },
            new Customer { Id = 2, FirstName = "Alex", LastName = "Rider" },
            new Customer { Id = 3, FirstName = "Thomas", LastName = "Meyer", IsDeveloper = true },
            new Customer { Id = 4, FirstName = "Anna", LastName = "Rockstar" },
            new Customer { Id = 5, FirstName = "Sara", LastName = "Metroid" },
            new Customer { Id = 6, FirstName = "Ben", LastName = "Ronaldo" }
        });
    }
}