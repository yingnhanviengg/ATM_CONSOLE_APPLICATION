using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Information;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Menu
{
    public class MenuAdmin : AbstractMenu
    {
        private static MenuAdmin _menuAdmin;
        public static MenuAdmin _MenuAdmin
        {
            get
            {
                if (_menuAdmin == null)
                {
                    _menuAdmin = new MenuAdmin();
                }
                return _menuAdmin;
            }
        }
        public override void ShowMenu()
        {
        ResetLanguage:
            string[] Menu_Admin = { AbstractLanguage.Information_Manager_Admin, AbstractLanguage.Card_Manager_Admin, AbstractLanguage.Recharge_Manager_Admin, AbstractLanguage.Transaction_History_Manager_Admin, AbstractLanguage.Change_Language, AbstractLanguage.LogOut };
            Common.UI();
            do
            {
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
                        Console.Clear();
                        Transaction.TransactionAdmin transactionAdmin = Transaction.TransactionAdmin._TransactionAdmin;
                        transactionAdmin.MenuTransaction();
                        break;
                    case 4:
                        Console.Clear();
                        ChangeLanguage.Change_Language();
                        goto ResetLanguage;
                    case 5:
                        Console.Clear();
                        MainMenu mainMenu = MainMenu._MainMenu;
                        mainMenu.Login();
                        break;
                }
            } while (true);
        }
    }
}
