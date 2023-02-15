using ATM_CONSOLE_APPLICATION.Controller;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Table = Spectre.Console.Table;

namespace ATM_CONSOLE_APPLICATION.View
{
    public class Information
    {      
        public static void TableInformation_User()
        {                          
            Table table = new Table();
            table.Border(TableBorder.AsciiDoubleHead);
            table.Expand();
            table.AddColumn("[springgreen2_1]Họ Và Tên[/]");
            table.AddColumn("[springgreen2_1]Ngày/Tháng/Năm Sinh[/]");
            table.AddColumn("[springgreen2_1]Giới Tính[/]");
            table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
            table.AddColumn("[springgreen2_1]Địa Chỉ[/]");
            table.AddColumn("[springgreen2_1]Email[/]");
            table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
            foreach (var item in ControllerUser.ListUsers)
            {
                table.AddRow($"{item.FullName}", $"{DateOfBirthToString(item.DateOfBirth)}", $"{item.Gender}", $"{item.CMND_CCCD}", $"{item.Address}", $"{item.Email}", $"{item.Phone}");
            }
            AnsiConsole.Write(table);              
            table.Rows.Clear();         
        }
        private static string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
        public void TableInformation_Admin()
        {
            int pageNumber = 1;
            int pageCount = (ControllerUser.ListUsers.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerUser.ListUsers.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"Sinh viên hiển thị {pageCount} trang, {ControllerUser.ListUsers.Count} sinh viên ");
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
            if (ControllerUser.ListUsers.Count == 0)
            {
                Console.WriteLine("Ko có dữ liệu");
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn("[springgreen2_1]ID SV[/]");
                table.AddColumn("[springgreen2_1]Họ Và Tên[/]");
                table.AddColumn("[springgreen2_1]Ngày Sinh[/]");
                table.AddColumn("[springgreen2_1]Giới Tính[/]");
                table.AddColumn("[springgreen2_1]Địa Chỉ[/]");
                table.AddColumn("[springgreen2_1]ID Khoa[/]");
                table.AddColumn("[springgreen2_1]Tên Khoa[/]");
                table.AddColumn("[springgreen2_1]Tên Môn[/]");
                table.AddColumn("[springgreen2_1]Tên Lớp[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine("Số trang không hợp lệ.");
                    return;
                }

                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerUser.ListUsers.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"");
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"Trang {pageNumber}/{pageCount}");
                table.Rows.Clear();
            }
        }
    }
}
