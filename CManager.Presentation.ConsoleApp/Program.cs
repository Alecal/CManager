using CManager.Presentation.ConsoleApp.Views; // This "plugs in" your views

Console.OutputEncoding = System.Text.Encoding.UTF8;

MainMenuView menu = new();
menu.Show();