namespace ATM_CONSOLE_APPLICATION
{
    public class Common
    {
        public static int Choose()
        {
            while (true)
            {
                try
                {
                    Console.Write(Language.Input_choose);
                    int x = Convert.ToInt32(Console.ReadLine());
                    return x;
                }
                catch (FormatException)
                {
                    PrintMessage_Console(Language.Exception_choose, false);
                }
            }
        }
        public static void PrintMessage_Console(string str, bool status)
        {
            if (status)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static bool Edit()
        {
            while (true)
            {
                Console.WriteLine(Language.IsUpdate);
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
                else { Console.WriteLine(Language.IsY_or_N); }
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
                else { Console.WriteLine(Language.IsY_or_N); }
            }
        }
    }
}
