using CManager.Domain.Models;

namespace CManager.Domain.Interfaces;

public interface ICustomerService
{
    bool CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city);

    IEnumerable<Customer> GetAllCustomers(out bool hasError);

    Customer GetCustomer(string id);
}
