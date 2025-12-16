namespace CManager.Presentation.ConsoleApp.Views;

public class UIHelper
{
    public static void DrawHeader(string title, int width, bool box = false)
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

    public static void DrawFooter(int width)
    {
        Console.WriteLine("└" + new string('─', width - 2) + "┘");
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