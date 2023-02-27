using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION
{
    public class Common
    {
        public static void UI()
        {
            AnsiConsole.Write(
                new FigletText("ATM CONSOLE APPLICATION")
                .Centered()
                .Color(Color.Red));
        }
        public static bool IsConfirm_Recharge()
        {
            while (true)
            {
                Console.WriteLine(Language.AbstractLanguage.IsConfirm_Recharge);
                string x = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                if (x.ToUpper().Equals("Y"))
                {
                    return true;
                }
                else if (x.ToUpper().Equals("N"))
                {
                    return false;
                }
                else { Console.WriteLine(Language.AbstractLanguage.IsY_or_N); }
            }
        }
        public static void PrintMessage_Console(string str, bool status)
        {
            if (status) { Console.ForegroundColor = ConsoleColor.Green; }
            else { Console.ForegroundColor = ConsoleColor.Red; }
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static bool Edit()
        {
            while (true)
            {
                Console.WriteLine(Language.AbstractLanguage.IsUpdate);
                string x = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                if (x.ToUpper().Equals("Y"))
                {
                    return true;
                }
                else if (x.ToUpper().Equals("N"))
                {
                    return false;
                }
                else { Console.WriteLine(Language.AbstractLanguage.IsY_or_N); }
            }
        }
        public static bool CreatedCard()
        {
            while (true)
            {
                string x = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                if (x.ToUpper().Equals("Y"))
                {
                    return true;
                }
                else if (x.ToUpper().Equals("N"))
                {
                    return false;
                }
                else { Console.WriteLine(Language.AbstractLanguage.IsY_or_N); }
            }
        }
    }
}
