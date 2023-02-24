using ATM_CONSOLE_APPLICATION.View.Login_Register;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.Language
{
    public class ChangeLanguage
    {
        public static void Change_Language()
        {           
            string[] Menu_Customer = { "English", "Vietnamese" };              
            while (true)
            {
                Common.UI();
                AbstractLanguage language;
                var menuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("")
                    .PageSize(10)
                    .AddChoices(Menu_Customer));

                int selectedIndex = Array.IndexOf(Menu_Customer, menuSelection);
                switch (selectedIndex)
                {
                    case 0:
                        language = new English();
                        language.ChangeLanguage();
                        break;
                    case 1:
                        language = new VietNamese();
                        language.ChangeLanguage();
                        break;
                    default:
                        Common.PrintMessage_Console("Error", false);
                        break;
                }
                if (selectedIndex == 0 || selectedIndex == 1)
                {
                    break;
                }
            }
        }
    }
}
