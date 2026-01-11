namespace CManager.Presentation.ConsoleApp.Views;
using CManager.Domain.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Repo;
using CManager.Infrastructure.Services;
using CManager.Presentation.ConsoleApp.Helpers;
using System.Linq;

public class ViewAllCustomersView
{
    private readonly ICustomerService _customerService;

    public ViewAllCustomersView()
    {
        var repo = new CustomerRepo();
        _customerService = new CustomerService(repo);
    }

    private void ViewAllCustomers()
    {
        Console.Clear();
        UIHelper.DrawHeader("", 56, false);
        UIHelper.DrawLine("Showing all customers:", 56, true);
        UIHelper.DrawFooter(56);

        var customers = _customerService.GetAllCustomers(out bool hasError);

        if (hasError)
        {
            Console.WriteLine("Something went wrong. Please try again later");
        }

        if (!customers.Any())
        {
            Console.WriteLine("No customers found");
        }
        else
        {

            var customerArray = customers.ToArray();

            for (int index = 0; index < customerArray.Length; index++)
            {
                var customer = customerArray[index];
                int displayCount = index + 1;

                UIHelper.DrawHeader($"ID: {customer.Id}", 56, true);
                UIHelper.DrawEmptyBox(56, true);
                UIHelper.DrawLine($"Name: {customer.FirstName} {customer.LastName}", 56, true);
                UIHelper.DrawLine($"Email: {customer.Email}", 56, true);

                UIHelper.DrawLine($"Phone: {FormattingService.Mobile(customer.PhoneNumber)}", 56, true);
                UIHelper.DrawEmptyBox(56, true);
                UIHelper.DrawLine($"Address:", 56, true);
                UIHelper.DrawLine($"{customer.Address.StreetAddress}", 56, true);

                UIHelper.DrawLine($"{FormattingService.Postalcode(customer.Address.PostalCode)}, {customer.Address.City.ToUpper()}", 56, true);

                UIHelper.DrawEmptyBox(56, true);
                UIHelper.DrawFooter(56, $" ─ {displayCount} ─ ", "grey");
                UIHelper.DrawEmptyBox(56, false);
            }
        }
    }

    public void Show()
    {
        ViewAllCustomers();
        Console.WriteLine("Enter customer number to edit customer...");
        Console.ReadLine();
        Console.Clear();
    }
}
