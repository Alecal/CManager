using CManager.Domain.Models;
namespace CManager.Application.Services;

public class CustomerService
{
    public bool CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAdress, string city, string postalCode)
    {
        Customer newCustomer = new()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            PhoneNumber = phoneNumber,
            Address = new Adress
            {
                StreetAddress = streetAdress,
                City = city,
                PostalCode = postalCode
            }
        };
        try
        {
            return true;
        }
        catch (Exception)
        {
            return false;
        }

    }
}
