using CManager.Domain.Models;

namespace CManager.Domain.Interfaces;

public interface ICustomerRepo
{
    bool AddCustomer(List<Customer> customers);
    List<Customer> GetAll();
    Customer GetCustomer(string id);
    bool Delete(string id);
}
