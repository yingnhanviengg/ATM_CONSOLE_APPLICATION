using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.Language
{
    public class ChangeLanguage
    {
        public static void Change_Language()
        {
            Console.Clear();
            string[] Menu_Customer = { "English", "Vietnamese" };
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
            }
        }
    }
}
