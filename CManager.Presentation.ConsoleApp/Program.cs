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

static void DrawFooter(int width)
{
    Console.WriteLine("└" + new string('─', width - 2) + "┘");
}

static void DrawLine(string text, int width, bool centered = false)
{

    int padding = 2;
    int fullLengthPadding = (width - text.Length);
    string textToDraw = new string(' ', padding) + text + new string(' ', padding);

    int totalLines = width - 2 - text.Length;
    int left = totalLines / 2;
    int right = totalLines - left;

    if (centered)
        Console.WriteLine("│" + new string(' ', left) + text + new string(' ', right) + "│");
    else
        Console.WriteLine($"│{textToDraw.PadRight(width - 2)}│");

}

static void DrawMenuItem(int width, string text, bool active = false)
{
    if (active)
    {
        Console.Write("│ > ");

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;


        int fullLength = text.Length + 5;
        Console.Write(text);

        Console.ResetColor();

        int remainingSpace = width - (fullLength);
        Console.WriteLine(new string(' ', remainingSpace) + "│");

    }
    else
    {
        Console.WriteLine($"│  {text.PadRight(width-5)} │");
    }
}

static void DrawEmptyBox(int width, bool lines = true)
{
    if (lines)
        Console.WriteLine($"│{new string(' ', width - 2)}│");
    else
        Console.WriteLine($"{new string(' ', width)}");
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




    DrawEmptyBox(56, false);
    DrawHeader(" MAIN MENU ", 56, true);
    DrawEmptyBox(56, true);
    DrawLine("Use arrowkeys to navigate and choose an option:", 56 , true);
    DrawEmptyBox(56, true);
  
    for (int i = 0; i < menuItems.Length; i++)
    {
        if (i == selectedItem)
        {
            DrawMenuItem(56, menuItems[i], true);
        }
        else
        {
            DrawMenuItem(56, menuItems[i], false);
        }
    }

    DrawEmptyBox(56, true);
    DrawFooter(56);


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