using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Information;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Menu
{
    public class MenuCustomer : AbstractMenu
    {
        public override void Menu()
        {
            string[] Menu_Customer = { AbstractLanguage.Information_Customer, AbstractLanguage.Card_Customer, AbstractLanguage.Withdraw_Money_Customer, AbstractLanguage.Recharge_Customer, AbstractLanguage.Tranfer_Money_Customer, AbstractLanguage.Bank_Deposit_Customer, AbstractLanguage.Transaction_History_Customer, AbstractLanguage.Change_Language };
            for (int i = 0; i < Menu_Customer.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu_Customer[i]}");
            }
        }

        public override void ShowMenu()
        {
            string[] Menu_Customer = { AbstractLanguage.Information_Customer, AbstractLanguage.Card_Customer, AbstractLanguage.Withdraw_Money_Customer, AbstractLanguage.Recharge_Customer, AbstractLanguage.Tranfer_Money_Customer, AbstractLanguage.Bank_Deposit_Customer, AbstractLanguage.Transaction_History_Customer, AbstractLanguage.Change_Language };
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
                        break;
                    case 3:
                        Console.Clear();
                        Recharge.RechargeCustomer recharge = Recharge.RechargeCustomer._RechargeCustomer;
                        recharge.Recharge();
                        break;
                    case 4:
                        Console.Clear();
                        TranferMoney.TranferCustomer tranfer = TranferMoney.TranferCustomer._TranferCustomer;
                        tranfer.Tranfer();
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.Clear();
                        Transaction.TransactionCustomer transactionCustomer = new Transaction.TransactionCustomer(); //updTE
                        transactionCustomer.MenuTransaction();
                        break;
                    case 7:
                        ChangeLanguage.Change_Language();
                        break;
                }
            } while (true);
        }
        public void ShowMenu2()
        {
            AnsiConsole.Write(
                new FigletText("ATM CONSOLE APPLICATION")
                    .LeftJustified()
                    .Color(Color.Red));
            do
            {
                Menu();
                switch (Common.Choose())
                {
                    case 1:
                        Console.Clear();
                        InformationCustomer customer = InformationCustomer._InformationCustomer;
                        customer.Information_Manager();
                        break;
                    case 2:
                        Console.Clear();
                        Card.CardCustomer cardCustomer = Card.CardCustomer._CardCustomer;
                        cardCustomer.Card_Management();
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.Clear();
                        Recharge.RechargeCustomer recharge = Recharge.RechargeCustomer._RechargeCustomer;
                        recharge.Recharge();
                        break;
                    case 5:
                        Console.Clear();
                        TranferMoney.TranferCustomer tranfer = TranferMoney.TranferCustomer._TranferCustomer;
                        tranfer.Tranfer();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        Console.Clear();
                        Transaction.TransactionCustomer transactionCustomer = new Transaction.TransactionCustomer();
                        transactionCustomer.Table_HistoryTranfer();
                        break;
                }
            } while (true);
        }
    }
}
