using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_CONSOLE_APPLICATION.View;

namespace ATM_CONSOLE_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "ATM CONSOLE APPLICATION";
            MainMenu mainMenu = new MainMenu();
            mainMenu.ShowMainMenu();
        }
    }
}