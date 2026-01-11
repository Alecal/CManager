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

        bool isRunning = true;

        while (isRunning)
        {
            ViewAllCustomers();
            var customers = _customerService.GetAllCustomers(out _).ToArray();

            Console.WriteLine("Enter [Customer Number] to edit, or leave empty and [Enter] to go back:");
            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "":
                    isRunning = false;
                    break;

                    // Tackar ai för denna
                case string s when int.TryParse(s, out int index) && index > 0 && index <= customers.Length:
                    // Få tag i kunden baserat på nummer i listan
                    var selectedCustomer = customers[index - 1];

                    EditCustomerView editView = new();

                    // Skicka med guiden som string till editView
                    editView.Show(selectedCustomer.Id.ToString());
                    break;

                default:
                    Console.WriteLine("Please enter a valid customer number!");
                    Console.ReadKey();
                    break;
            }
        }

        Console.Clear();
        Console.Write("\x1b[3J"); // Ta bort all text i konsolen
    }
}
