using CManager.Domain.Models;
namespace CManager.Domain.Interfaces;

public interface ICustomer
{
    Adress Address { get; set; }
    string Email { get; set; }
    string FirstName { get; set; }
    Guid Id { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
}
