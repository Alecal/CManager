using CManager.Domain.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Repo;

namespace CManager.Infrastructure.Services;

public class CustomerService : ICustomerService
{

    private readonly ICustomerRepo _customerRepo;
    public CustomerService(ICustomerRepo customerRepo)
    {
        _customerRepo = customerRepo;
    }
    public bool CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city)
    {
        Customer customerModel = new()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = new Adress
            {
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city
            }
        };

        try
        {
            var customers = _customerRepo.GetAll();
            customers.Add(customerModel);
            var result = _customerRepo.AddCustomer(customers);
            return result;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<Customer> GetAllCustomers(out bool hasError)
    {
        hasError = false;

        try
        {
            var customers = _customerRepo.GetAll();
            return customers;
        }
        catch (Exception)
        {
            // Error från customer repo kommer här
            hasError = true;
            return [];

        }

    }
}

