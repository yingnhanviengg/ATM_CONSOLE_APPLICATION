using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Transaction
{
    public class TransactionAdmin
    {
        private static TransactionAdmin? _transactionAdmin;
        public static TransactionAdmin _TransactionAdmin
        {
            get
            {
                if (_transactionAdmin == null)
                {
                    _transactionAdmin = new TransactionAdmin();
                }
                return _transactionAdmin;
            }
        }
        public void MenuTransaction()
        {
            string[] Menu_Customer = { AbstractLanguage.History_Tranfer, AbstractLanguage.History_Withdraw_Recharge, Language.AbstractLanguage.BackMenu };
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
                        Table_HistoryTranfer();
                        break;
                    case 1:
                        Console.Clear();
                        Table_HistoryRecharge();
                        break;
                    case 2:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                }
            } while (true);
        }
        public void Table_HistoryRecharge()
        {
            int pageNumber = 1;
            int pageCount = (ControllerTransaction.List_Transactions.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerTransaction.List_Transactions.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"{AbstractLanguage.Show} {pageCount} {AbstractLanguage.page}, {ControllerTransaction.List_Transactions.Count} {AbstractLanguage.Transaction}");
                        Console.Write(AbstractLanguage.EnterPage);
                        pageNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(AbstractLanguage.ErrorFormat);
                    }
                }
            }
            if (ControllerTransaction.List_Transactions.Count == 0)
            {
                Console.WriteLine(AbstractLanguage.Nodataavailable);
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.TransactionID}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.FullName}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Bankaccountnumber}[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.PhoneNumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Transactiontype}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Transactionamount}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.TimeTransaction}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.TransactionStatus}[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine(AbstractLanguage.Invalidpagenumber);
                    return;
                }
                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerTransaction.List_Transactions.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"{item.ID_Transaction}", $"{item.Bank_Account.User.FullName}", $"{item.Bank_Account.Number_Bank}", $"{item.Bank_Account.User.Email}", $"{item.Bank_Account.User.Phone}", $"{item.Type_Tracsaction}", $"{item.amount} VNĐ", $"{item.created_at_transaction}", $"{item.status_transaction}");
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"{AbstractLanguage.page} {pageNumber}/{pageCount}");
                table.Rows.Clear();
            }
        }
        public void Table_HistoryTranfer()
        {
            int pageNumber = 1;
            int pageCount = (ControllerTranfer.List_TranferMoney.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerTranfer.List_TranferMoney.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"{AbstractLanguage.Show} {pageCount} {AbstractLanguage.page}, {ControllerTranfer.List_TranferMoney.Count} {AbstractLanguage.Transaction}");
                        Console.Write(AbstractLanguage.EnterPage);
                        pageNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(AbstractLanguage.ErrorFormat);
                    }
                }
            }
            if (ControllerTranfer.List_TranferMoney.Count == 0)
            {
                Console.WriteLine(AbstractLanguage.Nodataavailable);
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.TransactionID}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.FullNameSender}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Bankaccountnumber}[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.PhoneNumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.transferamount}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.FullNamerecipients}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Bankaccountnumber}[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.PhoneNumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.transfertime}[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine(AbstractLanguage.Invalidpagenumber);
                    return;
                }
                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerTranfer.List_TranferMoney.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"{item.ID_Tranfer}", $"{item.Bank_Sender.User.FullName}", $"{item.Bank_Sender.Number_Bank}", $"{item.Bank_Sender.User.CMND_CCCD}", $"{item.Bank_Sender.User.Email}", $"{item.Bank_Sender.User.Phone}", $"{item.amount} VNĐ", $"{item.Bank_Recipient.User.FullName}", $"{item.Bank_Recipient.Number_Bank}", $"{item.Bank_Recipient.User.CMND_CCCD}", $"{item.Bank_Recipient.User.Email}", $"{item.Bank_Recipient.User.Phone}", $"{item.created_at_tranfer}");
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"{AbstractLanguage.page} {pageNumber}/{pageCount}");
            }
        }
        public string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
