using CManager.Domain.Interfaces;
using CManager.Infrastructure.Repo;
using CManager.Infrastructure.Services;
using CManager.Presentation.ConsoleApp.Helpers;

namespace CManager.Presentation.ConsoleApp.Views;

public class EditCustomerView
{
    private readonly ICustomerService _customerService;

    public EditCustomerView()
    {
        var repo = new CustomerRepo();
        _customerService = new CustomerService(repo);
    }

    public void Show(string customerId)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.Write("\x1b[3J");

            var customer = _customerService.GetCustomer(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                Console.ReadKey();
                return;
            }

            UIHelper.DrawHeader($"ID: {customer.Id}", 56, true);
            UIHelper.DrawEmptyBox(56, true);

            UIHelper.DrawLine($"Name: {customer.FirstName} {customer.LastName}", 56, true);
            UIHelper.DrawLine($"Email: {customer.Email}", 56, true);
            UIHelper.DrawLine($"Phone: {FormattingService.Mobile(customer.PhoneNumber)}", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine("Address:", 56, true);
            UIHelper.DrawLine($"{customer.Address.StreetAddress}", 56, true);
            UIHelper.DrawLine($"{FormattingService.Postalcode(customer.Address.PostalCode)}, {customer.Address.City.ToUpper()}", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawFooter(56);
            UIHelper.DrawEmptyBox(56, false);

            Console.WriteLine("Type 'DELETE' to remove this customer, or leave empty to go back: ");

            // Tar input och gör till små bokstäver
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            switch (input)
            {
                case "delete":
                    //Här ska det tas bort customer
                    Console.WriteLine("Customer deleted. Press any key to go back to main menu...");
                    Console.ReadKey();
                    isRunning = false;
                    break;

                case "":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid command, press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}