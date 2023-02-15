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
                    Console.WriteLine(Language.Exception_choose);
                }
            }
        }
        public static bool YN()
        {
            while (true)
            {
                Console.WriteLine("Có muốn sửa giá trị này không? (Y hoặc N)");
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
                else { Console.WriteLine("Chỉ được nhập Y hoặc N"); }
            }
        }      
    }
}
