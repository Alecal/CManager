using CManager.Presentation.ConsoleApp.Helpers;

namespace CManager.Presentation.ConsoleApp.Views;

public class MainMenuView
{
    public void Show()
    {

    Console.OutputEncoding = System.Text.Encoding.UTF8;

    int selectedItem = 0;
        string[] menuItems =
        [
            "1. Create new customer",
            "2. View and manage all customers",
            "3. Find and edit customer",
            "",
            "4. Quit application"
        ];

        bool navigatingMenu = true;

    while (navigatingMenu)
    {
        Console.Clear();
            UIHelper.DrawLogo();


        UIHelper.DrawEmptyBox(56, false);
            UIHelper.DrawHeader(" MAIN MENU ", 56, true);
            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawLine("Use arrowkeys to navigate and choose an option:", 56 , true);
            UIHelper.DrawEmptyBox(56, true);
  
        for (int i = 0; i<menuItems.Length; i++)
        {
            if (i == selectedItem)
            {       
                    if(menuItems[i] != "")
                        UIHelper.DrawMenuItem(56, menuItems[i], true);
                    else
                        UIHelper.DrawEmptyBox(56, true);
                }
            else
            {
                    UIHelper.DrawMenuItem(56, menuItems[i], false);
            }
        }

            UIHelper.DrawEmptyBox(56, true);
            UIHelper.DrawFooter(56);


            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    selectedItem = 0;
                    break;
                case ConsoleKey.D2:
                    selectedItem = 1;
                    break;
                case ConsoleKey.D3:
                    selectedItem = 2;
                    break;
                case ConsoleKey.D4:
                    selectedItem = 4;
                    break;
            }

            if (key == ConsoleKey.UpArrow)
                {
                    selectedItem = (selectedItem == 0) ? menuItems.Length - 1 : selectedItem - 1;
                    if (menuItems[selectedItem] == "")
                        selectedItem--;
                }
            else if (key == ConsoleKey.DownArrow)
                {
                    selectedItem = (selectedItem == menuItems.Length - 1) ? 0 : selectedItem + 1;
                    if (menuItems[selectedItem] == "")
                        selectedItem++;
                }
            else if (key == ConsoleKey.Enter)
                {
                    if (selectedItem == 0)
                    {
                        NewCustomerView customerView = new();
                        customerView.Show();
                    }
                    else if (selectedItem == 1)
                    {
                         ViewAllCustomersView customerView = new();
                         customerView.Show();
                    }
                    else if (selectedItem == 2)
                    {
                        Console.WriteLine("Not yet! Press any key to continue...");
                        Console.ReadKey();
                    }
                    else if (selectedItem == 3)
                    {
                        navigatingMenu = false;
                    }
                }   
        }
    }
}
