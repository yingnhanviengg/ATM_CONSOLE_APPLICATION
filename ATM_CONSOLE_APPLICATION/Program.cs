using ATM_CONSOLE_APPLICATION.View;
using System.Text;

namespace ATM_CONSOLE_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "ATM CONSOLE APPLICATION";
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowMainMenu();
        }
    }
}