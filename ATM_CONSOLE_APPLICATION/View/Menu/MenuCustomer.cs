using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Information;
using ATM_CONSOLE_APPLICATION.View.Login_Register;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Menu
{
    public class MenuCustomer : AbstractMenu
    {
        private static MenuCustomer _menuCustomer;
        public static MenuCustomer _MenuCustomer
        {
            get
            {
                if (_menuCustomer == null)
                {
                    _menuCustomer = new MenuCustomer();
                }
                return _menuCustomer;
            }
        }
        public override void ShowMenu()
        {
            ResetLanguage:
            string[] Menu_Customer = { AbstractLanguage.Information_Customer, AbstractLanguage.Card_Customer, AbstractLanguage.Recharge_Customer, AbstractLanguage.Tranfer_Money_Customer, AbstractLanguage.Transaction_History_Customer, AbstractLanguage.Change_Language, AbstractLanguage.LogOut };        
            Common.UI();
            do
            {
                var menuSelection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("")
                        .PageSize(10)                        
                        .AddChoices(Menu_Customer));
                int selectedIndex = Array.IndexOf(Menu_Customer, menuSelection);
                switch (selectedIndex)
                {
                    case 0:
                        Console.Clear();
                        InformationCustomer customer = InformationCustomer._InformationCustomer;
                        customer.Information_Manager();
                        break;
                    case 1:
                        Console.Clear();
                        Card.CardCustomer cardCustomer = Card.CardCustomer._CardCustomer;
                        cardCustomer.Card_Management();
                        break;
                    case 2:
                        Console.Clear();
                        Recharge.RechargeCustomer recharge = Recharge.RechargeCustomer._RechargeCustomer;
                        recharge.Recharge();
                        break;
                    case 3:
                        Console.Clear();
                        TranferMoney.TranferCustomer tranfer = TranferMoney.TranferCustomer._TranferCustomer;
                        tranfer.Tranfer();
                        break;
                    case 4:
                        Console.Clear();
                        Transaction.TransactionCustomer transactionCustomer = new Transaction.TransactionCustomer();
                        transactionCustomer.MenuTransaction();
                        break;
                    case 5:
                        Console.Clear();
                        ChangeLanguage.Change_Language();
                        goto ResetLanguage;
                    case 6:
                        Console.Clear();
                        MainMenu mainMenu = MainMenu._MainMenu;
                        mainMenu.Login();
                        break;
                }
            } while (true);
        }
    }
}
