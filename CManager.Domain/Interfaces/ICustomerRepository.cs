using CManager.Domain.Models;

namespace CManager.Domain.Interfaces;

public interface ICustomerRepository
{
    bool Add(Customer customer);
    IEnumerable<Customer> GetAll();
    Customer GetCustomer(string id);
    bool Delete(string id);
}
