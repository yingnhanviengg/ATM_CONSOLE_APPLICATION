using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string[] Menu_Customer = { AbstractLanguage.History_Tranfer, AbstractLanguage.History_Withdraw_Recharge, AbstractLanguage.unLock_account, Language.AbstractLanguage.BackMenu };
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
                        break;
                    case 2:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                }
            } while (true);
        }
        public void Table_HistoryTranfer()
        {
            int pageNumber = 1;
            int pageCount = (ControllerBank_User.ListBank_User.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerBank_User.ListBank_User.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"Giao dịch chuyển tiền {pageCount} trang, {ControllerBank_User.ListBank_User.Count} giao dịch ");
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
            if (ControllerBank_User.ListBank_User.Count == 0)
            {
                Console.WriteLine("Ko có dữ liệu");
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn("[springgreen2_1]Người Chuyển[/]");
                table.AddColumn("[springgreen2_1]Người Nhận[/]" );
                table.AddColumn("[springgreen2_1]Họ Và Tên Người Chuyển[/]");
                table.AddColumn("[springgreen2_1]Số Tài Khoản Người Chuyển[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn("[springgreen2_1]Số Tài Khoản[/]");
                table.AddColumn("[springgreen2_1]Số Dư[/]");
                table.AddColumn("[springgreen2_1]Địa Chỉ[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine("Số trang không hợp lệ.");
                    return;
                }

                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerBank_User.ListBank_User.Skip(startIndex).Take(pageSize).ToList())
                    {
                        if (item.User.status_user.Equals("normal"))
                        {
                            table.AddRow($"{item.User.ID_User}", $"{item.User.FullName}", $"{item.User.DateOfBirth}", $"{item.User.Gender}", $"{item.User.CMND_CCCD}", $"{item.Number_Bank}", $"{item.Balance}", $"{item.User.Address}", $"{item.User.Email}", $"{item.User.Phone}");

                        }
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"Trang {pageNumber}/{pageCount}");
                table.Rows.Clear();
            }
        }
    }
}
