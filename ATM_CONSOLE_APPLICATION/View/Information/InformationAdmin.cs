using ATM_CONSOLE_APPLICATION.Controller;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Information
{
    public class InformationAdmin : AbstractInformation
    {
        private static InformationAdmin? _informationAdmin;

        private InformationAdmin()
        {

        }
        public static InformationAdmin _InformationAdmin
        {
            get
            {
                if (_informationAdmin == null)
                {
                    _informationAdmin = new InformationAdmin();
                }
                return _informationAdmin;
            }
        }
        public override void Table_Informatio()
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
                        Console.WriteLine($"Khách hàng hiển thị {pageCount} trang, {ControllerBank_User.ListBank_User.Count} khách hàng ");
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
                table.AddColumn("[springgreen2_1]Họ Và Tên[/]");
                table.AddColumn("[springgreen2_1]Ngày/Tháng/Năm Sinh[/]");
                table.AddColumn("[springgreen2_1]Giới Tính[/]");
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
                        table.AddRow($"{item.FullName}", $"{DateOfBirthToString(item.DateOfBirth)}",
                            $"{item.Gender}", $"{item.CMND_CCCD}",
                            $"{item.Number_Bank}", $"{item.Balance}", $"{item.Address}",
                            $"{item.Email}", $"{item.Phone}");
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"Trang {pageNumber}/{pageCount}");
                table.Rows.Clear();
            }
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
