Console.OutputEncoding = System.Text.Encoding.UTF8;

int selectedItem = 0;
string[] menuItems = new string[]
{
    "Create new customer",
    "View all customers",
    "Quit application"
};

bool navigatingMenu = true;

while (navigatingMenu)
{
    Console.ResetColor();
    Console.Clear();
    Console.WriteLine("┌────────────────────── MENU ─────────────────────────┐");
    Console.WriteLine("│                                                     │");
    Console.WriteLine("│ Use arrowkeys to navigate and choose an option:     │");
    Console.WriteLine("│                                                     │");

    for (int i = 0; i < menuItems.Length; i++)
    {
        if (i == selectedItem)
        {
            Console.Write("│ > ");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

                Console.Write($" {menuItems[i]} ");

            Console.ResetColor();

            int remainingSpace = 48 - menuItems[i].Length;
            Console.WriteLine(new string(' ', remainingSpace) + "│");

        }
        else
        {
            Console.WriteLine($"│  {menuItems[i].PadRight(50)} │");
        }
    }

    Console.WriteLine("│                                                     │");
    Console.WriteLine("└─────────────────────────────────────────────────────┘");


    var key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.UpArrow)
    { selectedItem = (selectedItem == 0) ? menuItems.Length - 1 : selectedItem - 1;}
    else if
        (key == ConsoleKey.DownArrow)
    { selectedItem = (selectedItem == menuItems.Length - 1) ? 0 : selectedItem + 1; }
    else if
        (key == ConsoleKey.Enter)
    {
        if (selectedItem == 0)
        {
            Console.WriteLine("Navigating to: Create Customer...");
            Console.ReadKey();
        }
        else if (selectedItem == 1)
        {
            Console.WriteLine("Navigating to: View All...");
            Console.ReadKey();
        }
        else if (selectedItem == 2)
        {
            navigatingMenu = false;
        }
    }
}