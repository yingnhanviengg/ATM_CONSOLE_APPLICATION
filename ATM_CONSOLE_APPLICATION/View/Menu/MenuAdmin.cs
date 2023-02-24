using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Information;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Menu
{
    public class MenuAdmin : AbstractMenu
    {
        public override void Menu()
        {
            AnsiConsole.Write(
                new FigletText("ATM CONSOLE APPLICATION")
                    .LeftJustified()
                    .Color(Color.Red));
            string[] Menu_Admin = { AbstractLanguage.Information_Manager_Admin, AbstractLanguage.Card_Manager_Admin, AbstractLanguage.Recharge_Manager_Admin, AbstractLanguage.Transaction_History_Manager_Admin, AbstractLanguage.Change_Language };
            for (int i = 0; i < Menu_Admin.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu_Admin[i]}");
            }
        }
        public override void ShowMenu()
        {
            do
            {
                Common.UI();

                string[] Menu_Admin = { AbstractLanguage.Information_Manager_Admin, AbstractLanguage.Card_Manager_Admin, AbstractLanguage.Recharge_Manager_Admin, AbstractLanguage.Transaction_History_Manager_Admin, AbstractLanguage.Change_Language };
                var menuSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("")
                        .PageSize(10)
                        .AddChoices(Menu_Admin));

                int selectedIndex = Array.IndexOf(Menu_Admin, menuSelection);

                switch (selectedIndex)
                {
                    case 0:
                        Console.Clear();
                        InformationAdmin admin = InformationAdmin._InformationAdmin;
                        admin.Information_Manager();
                        break;
                    case 1:
                        Console.Clear();
                        Card.CardAdmin cardAdmin = Card.CardAdmin._CardAdmin;
                        cardAdmin.Card_Management();
                        break;
                    case 2:
                        Console.Clear();
                        Recharge.RecchargeAdmin recchargeAdmin = Recharge.RecchargeAdmin._RecchargeAdmin;
                        recchargeAdmin.Confirm_Reccharge();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine(Language.AbstractLanguage.Exception_choose_switch);
                        break;
                }
            } while (true);
        }
        public void ShowMenu2()
        {
            do
            {
                Menu();
                switch (Common.Choose())
                {
                    case 1:
                        Console.Clear();
                        InformationAdmin admin = InformationAdmin._InformationAdmin;
                        admin.Information_Manager();
                        break;
                    case 2:
                        Console.Clear();
                        Card.CardAdmin cardAdmin = Card.CardAdmin._CardAdmin;
                        cardAdmin.Card_Management();
                        break;
                    case 3:
                        Console.Clear();
                        Recharge.RecchargeAdmin recchargeAdmin = Recharge.RecchargeAdmin._RecchargeAdmin;
                        recchargeAdmin.Confirm_Reccharge();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine(Language.AbstractLanguage.Exception_choose_switch);
                        break;
                }
            } while (true);
        }
    }
}
