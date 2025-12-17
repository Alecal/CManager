namespace CManager.Presentation.ConsoleApp.Views;
using CManager.Domain.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Repo;
using CManager.Infrastructure.Services;
using CManager.Presentation.ConsoleApp.Helpers;

public class ViewAllCustomersView
{
    // 1. Declare the field
    private readonly ICustomerService _customerService;

    // 2. Initialize it in the constructor
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
            int i = 0;
            foreach (var customer in customers)
            {
                i++;
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
                UIHelper.DrawFooter(56, $" ─ {i} ─ ", "grey");
                UIHelper.DrawEmptyBox(56,false);
            }
        }
    }

    public void Show()
    {
        ViewAllCustomers();
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}
