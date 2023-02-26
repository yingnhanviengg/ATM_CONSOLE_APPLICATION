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
                        Table_HistoryRecharge_Withdraw();
                        break;
                    case 2:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                }
            } while (true);
        }
        public void Table_HistoryRecharge_Withdraw()
        {
            int pageNumber = 1;
            int pageCount = (ControllerTransaction.ListHistoryRecharge_Withdraw_User.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerTransaction.ListHistoryRecharge_Withdraw_User.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"Giao dịch {pageCount} trang, {ControllerTransaction.ListHistoryRecharge_Withdraw_User.Count} giao dịch ");
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
            if (ControllerTransaction.ListHistoryRecharge_Withdraw_User.Count == 0)
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
                    foreach (var item in ControllerTransaction.ListHistoryRecharge_Withdraw_User.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"{item.ID_Transaction}", $"{item.Bank_Account.User.FullName}", $"{item.Bank_Account.Number_Bank}", $"{item.Bank_Account.User.Email}", $"{item.Bank_Account.User.Phone}", $"{item.Type_Tracsaction}", $"{item.amount}", $"{item.created_at_transaction}", $"{item.status_transaction}");
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
            int pageCount = (ControllerTranfer.List_TranferMoney_User.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerTranfer.List_TranferMoney_User.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"Giao dịch chuyển tiền {pageCount} trang, {ControllerTranfer.List_TranferMoney_User.Count} giao dịch ");
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
            if (ControllerTranfer.List_TranferMoney_User.Count == 0)
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
                    foreach (var item in ControllerTranfer.List_TranferMoney_User.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"{item.ID_Tranfer}", $"{item.Bank_Sender.User.FullName}", $"{item.Bank_Sender.Number_Bank}", $"{item.Bank_Sender.User.CMND_CCCD}", $"{item.Bank_Sender.User.Email}", $"{item.Bank_Sender.User.Phone}", $"{item.amount}", $"{item.Bank_Recipient.User.FullName}", $"{item.Bank_Recipient.Number_Bank}", $"{item.Bank_Recipient.User.CMND_CCCD}", $"{item.Bank_Recipient.User.Email}", $"{item.Bank_Recipient.User.Phone}", $"{item.created_at_tranfer}");
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
