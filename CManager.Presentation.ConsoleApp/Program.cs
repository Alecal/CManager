Console.OutputEncoding = System.Text.Encoding.UTF8;

int selectedItem = 0;
string[] menuItems =
[
    "Create new customer",
    "View all customers",
    "Quit application"
];

bool navigatingMenu = true;

static void DrawHeader(string title, int width, bool box = false)
{
    string formattedTitle = $" {title} ";

    int totalLines = width - 2 - formattedTitle.Length;
    int left = totalLines / 2;
    int right = totalLines - left;

    if (box)
        Console.WriteLine("┌" + new string('─', left) + formattedTitle + new string('─', right) + "┐");
    else
        Console.WriteLine("│" + new string(' ', left) + formattedTitle + new string(' ', right) + "│");

}

while (navigatingMenu)
{
    Console.Clear();

    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;

    

    Console.WriteLine("                                                        ");
    Console.WriteLine("  ▄█████ ██▄  ▄██  ▄▄▄  ▄▄  ▄▄  ▄▄▄   ▄▄▄▄ ▄▄▄▄▄ ▄▄▄▄   ");  
    Console.WriteLine("  ██     ██ ▀▀ ██ ██▀██ ███▄██ ██▀██ ██ ▄▄ ██▄▄  ██▄█▄  "); 
    Console.WriteLine("  ▀█████ ██    ██ ██▀██ ██ ▀██ ██▀██ ▀███▀ ██▄▄▄ ██ ██  ");
    Console.WriteLine("                                                        ");
    Console.WriteLine("            Customer management made simple!            ");
    Console.WriteLine("                                                        ");

    Console.ResetColor();


    Console.WriteLine("                                                        ");
    DrawHeader(" Main Menu ", 56, true);
    Console.WriteLine("│                                                      │");

    DrawHeader(" Use arrowkeys to navigate and choose an option: ", 56, false);

    Console.WriteLine("│                                                      │");

    for (int i = 0; i < menuItems.Length; i++)
    {
        if (i == selectedItem)
        {
            Console.Write("│ > ");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

                Console.Write($" {menuItems[i]} ");

            Console.ResetColor();

            int remainingSpace = 49 - menuItems[i].Length;
            Console.WriteLine(new string(' ', remainingSpace) + "│");

        }
        else
        {
            Console.WriteLine($"│  {menuItems[i].PadRight(51)} │");
        }
    }

    Console.WriteLine("│                                                      │");
    Console.WriteLine("└──────────────────────────────────────────────────────┘");


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