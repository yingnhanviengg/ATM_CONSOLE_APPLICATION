using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Card;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Recharge
{
    public class RecchargeAdmin
    {
        private static RecchargeAdmin? _recchargeAdmin;
        private RecchargeAdmin()
        {

        }
        public static RecchargeAdmin _RecchargeAdmin
        {
            get
            {
                if (_recchargeAdmin == null)
                {
                    _recchargeAdmin = new RecchargeAdmin();
                }
                return _recchargeAdmin;
            }
        }
        ControllerTransaction controllerTransaction = ControllerTransaction._ControllerRecharge;
        public void Confirm_Reccharge()
        {
            Table_Recharge();
            int idbank = InputisValid.InputIDTransaction();
            var item = ControllerTransaction.List_Transactions.FirstOrDefault(x => x.ID_Transaction.Equals(idbank));
            if (item != default)
            {
                if (controllerTransaction.Confirm_Reccharge(item))
                {
                    Common.PrintMessage_Console(AbstractLanguage.Confirm_Reacharge_Success, true);
                }
                else
                {
                    Common.PrintMessage_Console(AbstractLanguage.Confirm_Recharge_Error, false);
                }
            }
            else
            {
                Common.PrintMessage_Console(AbstractLanguage.NotFind_Transaction,false);
            }
        }
        public void Table_Recharge()
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
                        Console.WriteLine($"Khách hàng hiển thị {pageCount} trang, {ControllerTransaction.List_Transactions.Count} khách hàng ");
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
                table.AddColumn("[springgreen2_1]Số Tài Khoản[/]");
                table.AddColumn("[springgreen2_1]Họ Và Tên[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn("[springgreen2_1]Số Tài Khoản[/]");
                table.AddColumn("[springgreen2_1]Số Dư[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
                table.AddColumn("[springgreen2_1]Số Tiền Nạp[/]");
                table.AddColumn("[springgreen2_1]Trạng Thái Yêu Cầu[/]");
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
                        table.AddRow($"{item.ID_Transaction}", $"{item.Bank_Account.Number_Bank}", $"{item.User.FullName}", $"{item.User.CMND_CCCD}", $"{item.Bank_Account.Number_Bank}", $"{item.Bank_Account.Balance}", $"{item.User.Email}", $"{item.User.Phone}", $"{item.amount}", $"{item.status_transaction}");
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
