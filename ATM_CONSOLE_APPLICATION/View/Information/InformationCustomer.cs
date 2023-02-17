using ATM_CONSOLE_APPLICATION.Controller;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Table = Spectre.Console.Table;

namespace ATM_CONSOLE_APPLICATION.View.Information
{
    public class InformationCustomer : AbstractInformation
    {
        private static InformationCustomer? _informationCustomer;

        private InformationCustomer()
        {
            
        }
        public static InformationCustomer _InformationCustomer
        {
            get
            {
                if (_informationCustomer == null)
                {
                    _informationCustomer = new InformationCustomer();
                }
                return _informationCustomer;
            }           
        }
        public override void Table_Informatio()
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
            table.AddRow($"{ControllerBank_User.User.FullName}", $"{DateOfBirthToString(ControllerBank_User.User.DateOfBirth)}",
                $"{ControllerBank_User.User.Gender}", $"{ControllerBank_User.User.CMND_CCCD}",
                $"{ControllerBank_User.User.Number_Bank}", $"{ControllerBank_User.User.Balance}", $"{ControllerBank_User.User.Address}",
                $"{ControllerBank_User.User.Email}", $"{ControllerBank_User.User.Phone}");
            AnsiConsole.Write(table);
            table.Rows.Clear();
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }      
    }
}
