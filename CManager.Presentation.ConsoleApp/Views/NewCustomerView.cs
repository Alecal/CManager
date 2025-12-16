namespace CManager.Presentation.ConsoleApp.Views;

public class NewCustomerView
{
    public void Show()
    {
        bool isRunning = true;
        int success = 0;

        while (isRunning)
        {
            string firstName = "";
            string lastName = "";
            string email = "";
            int index = 0;

            

            while (index < 3)
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
                    UIHelper.DrawLine("Enter customer information below:", 56, true);
                }

                UIHelper.DrawEmptyBox(56, true);

                UIHelper.DrawLine(index == 0 ? "First name: █████████" : $"First name: {firstName}", 56, false);
                UIHelper.DrawLine(index == 1 ? "Last name: █████████" : $"Last name: {lastName}", 56, false);
                UIHelper.DrawLine(index == 2 ? "Email: █████████" : $"Email: {email}", 56, false);

                UIHelper.DrawEmptyBox(56, true);
                UIHelper.DrawFooter(56);

                switch (index)
                {
                    case 0:
                        Console.Write("  Enter First name: ");
                        firstName = Console.ReadLine() ?? "";
                        index++;
                    break;

                    case 1:
                        Console.Write("  Enter Last name: ");
                        lastName = Console.ReadLine() ?? "";
                        index++;
                    break;

                    case 2:
                        Console.Write("  Enter Email: ");
                        email = Console.ReadLine() ?? "";
                        index++;
                    break;
                }
            }

            Console.Clear();
            UIHelper.DrawLogo();
            UIHelper.DrawEmptyBox(56, false);
            UIHelper.DrawHeader("NEW CUSTOMER", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine($"{firstName} {lastName}", 56, true);
            UIHelper.DrawLine($"{email}", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine("Is this information correct?", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine("[Enter] Save | [Esc] Discard", 56, true);
            UIHelper.DrawFooter(56);

            var key = Console.ReadKey(true).Key;


            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);

            if (key == ConsoleKey.Enter)
            {
                // spara customer
                success = 1;

            }
                else if (key == ConsoleKey.Escape)
            {
                // tillbaka till start
                isRunning = false;
            }
        }
    }
}