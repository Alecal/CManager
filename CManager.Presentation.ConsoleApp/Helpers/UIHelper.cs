namespace CManager.Presentation.ConsoleApp.Helpers;

public class UIHelper
{
    public static void DrawHeader(string title, int width, bool box = false)
    {

        int totalLines = width - 2 - title.Length;
        int left = totalLines / 2;
        int right = totalLines - left;

        if (box)
            Console.WriteLine("┌" + new string('─', left) + title + new string('─', right) + "┐");
        else
            Console.WriteLine("│" + new string(' ', left) + title + new string(' ', right) + "│");

    }
    public static void DrawLogo()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("                                                        ");
        Console.WriteLine("  ▄█████ ██▄  ▄██  ▄▄▄  ▄▄  ▄▄  ▄▄▄   ▄▄▄▄ ▄▄▄▄▄ ▄▄▄▄   ");
        Console.WriteLine("  ██     ██ ▀▀ ██ ██▀██ ███▄██ ██▀██ ██ ▄▄ ██▄▄  ██▄█▄  ");
        Console.WriteLine("  ▀█████ ██    ██ ██▀██ ██ ▀██ ██▀██ ▀███▀ ██▄▄▄ ██ ██  ");
        Console.WriteLine("                                                        ");
        Console.WriteLine("            Customer management made simple!            ");
        Console.WriteLine("                                                        ");

        Console.ResetColor();
    }

    public static void DrawFooter(int width, string title = "", string color = "Black")
    {

        int totalLines = width - 2 - title.Length;
        int left = totalLines / 2;
        int right = totalLines - left;

        Console.Write("└" + new string('─', left));

        ConsoleColor selectedColor = color.ToLower() switch
        {
            "black" => ConsoleColor.Black,
            "grey" => ConsoleColor.DarkGray,
            "white" => ConsoleColor.White,
            _ => ConsoleColor.Black
        };
        Console.ForegroundColor = selectedColor;
        Console.Write(title);
        Console.ResetColor();
        Console.Write(new string('─', right) + "┘");
        Console.WriteLine();


    }

    public static void DrawLine(string text, int width, bool centered = false)
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

    public static void DrawMenuItem(int width, string text, bool active = false)
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
            Console.WriteLine($"│  {text.PadRight(width - 5)} │");
        }
    }

    public static void DrawEmptyBox(int width, bool lines = true)
    {
        if (lines)
            Console.WriteLine($"│{new string(' ', width - 2)}│");
        else
            Console.WriteLine($"{new string(' ', width)}");
    }
}