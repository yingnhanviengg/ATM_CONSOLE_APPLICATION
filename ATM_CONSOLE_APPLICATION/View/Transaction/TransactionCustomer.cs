using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Transaction
{
    public class TransactionCustomer
    {
        private static TransactionCustomer? _transactionCustomer;
        public static TransactionCustomer _TransactionCustomer
        {
            get
            {
                if (_transactionCustomer == null)
                {
                    _transactionCustomer = new TransactionCustomer();
                }
                return _transactionCustomer;
            }
        }
        private ControllerTransaction controllerTransaction = ControllerTransaction._ControllerTransaction;
        private ControllerTranfer controllerTranfer = ControllerTranfer._ControllerTranfer;
        public void ShowMenuTransaction()
        {
            string[] Menu = { AbstractLanguage.History_Tranfer, AbstractLanguage.History_Withdraw_Recharge, AbstractLanguage.BackMenu };
            for (int i = 0; i < Menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu[i]}");
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
                        Table_HistoryTranfer();
                        break;
                    case 1:
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
                        Console.WriteLine($"Giao dịch {pageCount} trang, {ControllerTransaction.List_Transactions.Count} giao dịch ");
                        Console.Write("Nhập số trang: ");
                        pageNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Nhập sai định dạng");
                    }
                }
            }
            if (ControllerTransaction.List_Transactions.Count == 0)
            {
                Console.WriteLine("Ko có dữ liệu");
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn("[springgreen2_1]ID Giao Dịch[/]");
                table.AddColumn("[springgreen2_1]Họ Và Tên[/]");
                table.AddColumn("[springgreen2_1]Số Tài Khoản[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
                table.AddColumn("[springgreen2_1]Loại Giao Dịch[/]");
                table.AddColumn("[springgreen2_1]Số Tiền Giao Dịch[/]");
                table.AddColumn("[springgreen2_1]Thời Gian Giao Dịch[/]");
                table.AddColumn("[springgreen2_1]Trạng Thái Giao Dịch[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine("Số trang không hợp lệ.");
                    return;
                }
                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerTransaction.List_Transactions.Skip(startIndex).Take(pageSize).ToList())
                    {
                        if (item.Bank_Account.ID_Bank.Equals(ControllerBank_User.UserBank.ID_Bank))
                        {
                            table.AddRow($"{item.ID_Transaction}", $"{item.User.FullName}", $"{item.Bank_Account.Number_Bank}", $"{item.User.Email}", $"{item.User.Phone}", $"{item.Type_Tracsaction}", $"{item.amount}", $"{item.created_at_transaction}", $"{item.status_transaction}");
                        }
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"Trang {pageNumber}/{pageCount}");
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
                        Console.WriteLine($"Giao dịch chuyển tiền {pageCount} trang, {ControllerTranfer.List_TranferMoney.Count} giao dịch ");
                        Console.Write("Nhập số trang: ");
                        pageNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Nhập sai định dạng");
                    }
                }
            }
            if (ControllerTranfer.List_TranferMoney.Count == 0)
            {
                Console.WriteLine("Ko có dữ liệu");
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn("[springgreen2_1]ID Giao Dịch[/]");
                table.AddColumn("[springgreen2_1]Họ Và Tên Người Chuyển[/]");
                table.AddColumn("[springgreen2_1]Số Tài Khoản[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
                table.AddColumn("[springgreen2_1]Số Tiền Chuyển[/]");
                table.AddColumn("[springgreen2_1]Họ Và Tên Người Nhận[/]");
                table.AddColumn("[springgreen2_1]Số Tài Khoản[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
                table.AddColumn("[springgreen2_1]Thời Gian Chuyển[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine("Số trang không hợp lệ.");
                    return;
                }
                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerTranfer.List_TranferMoney.Skip(startIndex).Take(pageSize).ToList())
                    {
                        if (item.Bank_Sender.ID_Bank.Equals(ControllerBank_User.UserBank.ID_Bank) || item.Bank_Recipient.ID_Bank.Equals(ControllerBank_User.UserBank.ID_Bank))
                        {
                            table.AddRow($"{item.ID_Tranfer}", $"{item.Bank_Sender.User.FullName}", $"{item.Bank_Sender.Number_Bank}", $"{item.Bank_Sender.User.CMND_CCCD}", $"{item.Bank_Sender.User.Email}", $"{item.Bank_Sender.User.Phone}", $"{item.amount}", $"{item.Bank_Recipient.User.FullName}", $"{item.Bank_Recipient.Number_Bank}", $"{item.Bank_Recipient.User.CMND_CCCD}", $"{item.Bank_Recipient.User.Email}", $"{item.Bank_Recipient.User.Phone}", $"{item.created_at_tranfer}");
                        }
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"Trang {pageNumber}/{pageCount}");
                table.Rows.Clear();
            }
        }
        public string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
