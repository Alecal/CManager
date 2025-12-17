using CManager.Domain.Interfaces;
using CManager.Domain.Models;

namespace CManager.Infrastructure.Repo;

public class CustomerRepository : ICustomerRepository
{
    public bool Add(Customer customer)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }

    public Customer GetCustomer(string id)
    {
        throw new NotImplementedException();
    }
}
