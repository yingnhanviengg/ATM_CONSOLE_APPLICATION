namespace ATM_CONSOLE_APPLICATION.Language
{
    public class ChangeLanguage
    {
        public static void Change_Language()
        {
            while (true)
            {
                int x;
                AbstractLanguage language;
                Console.WriteLine("1: English");
                Console.WriteLine("2: Vietnamese");
                switch (x = Common.Choose())
                {
                    case 1:
                        language = new English();
                        language.ChangeLanguage();
                        break;
                    case 2:
                        language = new VietNamese();
                        language.ChangeLanguage();
                        break;
                    default:
                        Common.PrintMessage_Console("Error", false);
                        break;
                }
                if (x == 1 || x == 2)
                {
                    break;
                }
            }
        }
    }
}
