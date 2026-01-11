using CManager.Infrastructure.Services;
using CManager.Infrastructure.Repo;
using CManager.Presentation.ConsoleApp.Helpers;

namespace CManager.Presentation.ConsoleApp.Views;

public class NewCustomerView
{
    public void Show()
    {
        bool isRunning = true;
        int success = 0;

        while (isRunning)
        {
            string firstName = "",
                lastName = "",
                email = "",
                streetName = "",
                city = "",
                phoneNumber = "",
                postalCode = "";
            

            int index = 0;

            while (index < 7)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();
                UIHelper.DrawLogo();
                UIHelper.DrawEmptyBox(56, false);
                UIHelper.DrawHeader("NEW CUSTOMER", 56, true);
                UIHelper.DrawEmptyBox(56, true);

                if (success == 1)
                {
                    UIHelper.DrawLine("Customer saved successfully!", 56, true);
                    UIHelper.DrawEmptyBox(56, true);
                    UIHelper.DrawLine("To add another, enter customer information below.", 56, true);
                    UIHelper.DrawLine("Or press [Esc] to go back to the main menu.", 56, true);
                    success = 0;
                }
                else
                {
                    UIHelper.DrawLine("Enter customer information below.", 56, true);
                    UIHelper.DrawLine("To undo entered field, press [Esc]", 56, true);
                }

                UIHelper.DrawEmptyBox(56, true);

                UIHelper.DrawLine(index == 0 ? "First name: ██████████████████" : $"First name: {firstName}", 56, false);
                UIHelper.DrawLine(index == 1 ? "Last name: ██████████████████" : $"Last name: {lastName}", 56, false);
                UIHelper.DrawLine(index == 2 ? "Phone number: ██████████████████" : $"Phone number: {phoneNumber}", 56, false);
                UIHelper.DrawLine(index == 3 ? "Email: ██████████████████" : $"Email: {email}", 56, false);
                UIHelper.DrawEmptyBox(56, true);
                UIHelper.DrawLine(index == 4 ? "Street name: ██████████████████" : $"Street name: {streetName}", 56, false);
                UIHelper.DrawLine(index == 5 ? "City: ██████████████████" : $"City: {city}", 56, false);
                UIHelper.DrawLine(index == 6 ? "Postal code: ██████████████████" : $"Postal code: {postalCode}", 56, false);

                UIHelper.DrawEmptyBox(56, true);
                UIHelper.DrawFooter(56);

                string input = "";

                switch (index)
                {
                    case 0: input = "  First name: "; break;
                    case 1: input = "  Last name: "; break;
                    case 2: input = "  Phone number: "; break;
                    case 3: input = "  Email: "; break;
                    case 4: input = "  Street name: "; break;
                    case 5: input = "  City: "; break;
                    case 6: input = "  Postal code: "; break;
                }


                Console.Write(input);

                string currentInput = "";
                bool escPressed = false;

                while (true)
                {
                    var keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                        if (index > 0)
                        {
                            // ångra fält
                            index --;
                            escPressed = true;
                            break;
                        }
                            else
                        {
                            // go tillbaka helt
                            return;
                        }
                                    

                    if (keyInfo.Key == ConsoleKey.Enter) break;

                    if (keyInfo.Key == ConsoleKey.Backspace && currentInput.Length > 0)
                    {
                        // ta bort sista tecknet 
                        currentInput = currentInput[..^1];
                        //flytta tillbaka pekaren och skriv ett mellanslag
                        Console.Write("\b \b");
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        currentInput += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                    }
                }


                if (escPressed) continue;


                switch (index)
                {
                    case 0: firstName = currentInput; break;
                    case 1: lastName = currentInput; break;
                    case 2: phoneNumber = currentInput; break;
                    case 3: email = currentInput; break;
                    case 4: streetName = currentInput; break;
                    case 5: city = currentInput; break;
                    case 6: postalCode = currentInput; break;

                }
                index++;
            }

            Console.Clear();
            UIHelper.DrawLogo();
            UIHelper.DrawEmptyBox(56, false);
            UIHelper.DrawHeader("NEW CUSTOMER", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine($"{firstName} {lastName}", 56, true);
            UIHelper.DrawLine($"Email: {email}", 56, false);
            UIHelper.DrawLine($"Phone: {phoneNumber}", 56, false);
            UIHelper.DrawLine($"{streetName}, {postalCode} {city.ToUpper()}", 56, false);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine("Is this information correct?", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine("[Enter] Save | [Esc] Discard", 56, true);
            UIHelper.DrawFooter(56);

            ConsoleKey finalKey;
            do
            {
                finalKey = Console.ReadKey(true).Key;
            } while (finalKey != ConsoleKey.Enter && finalKey != ConsoleKey.Escape);

            if (finalKey == ConsoleKey.Enter)
            {
                
                var customerRepo = new CustomerRepo();
                var customerService = new CustomerService(customerRepo);
                var result = customerService.CreateCustomer(firstName, lastName, email, phoneNumber, streetName, postalCode, city);

                if (result)
                {
                    Console.WriteLine("Customer created");
                    Console.WriteLine($"Name: {firstName} {lastName}");
                }
                else
                {
                    Console.WriteLine("Something went wrong. Please try again");
                }
                success = 1;
                
            }
            else if (finalKey == ConsoleKey.Escape)
            {
                isRunning = false;
            }
        }
    }
}