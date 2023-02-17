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
        public override void Information_Manager()
        {         
            do
            {
                Information_Manager_Menu();
                switch (Common.Choose())
                {
                    case 1:
                        Console.Clear();
                        Table_Informatio();
                        break;
                    case 2:
                        Console.Clear();
                        Update_Information();
                        break;
                    case 3:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        public override void Information_Manager_Menu()
        {
            string[] Menu_Customer = { Language.Check_Account_Information,  Language.Update_Information };
            for (int i = 0; i < Menu_Customer.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu_Customer[i]}");
            }
        }
        public override void Update_Information()
        {
            Table_Informatio();
            Console.WriteLine($"{Language.Name_Current}{Model.ModelBank_Account._UserBank.FullName}");
            Model.ModelBank_Account._UserBank.FullName = Common.Edit() ? InputisValid.InputFullName() : Model.ModelBank_Account._UserBank.FullName;

            Console.WriteLine($"{Language.DateOfBirth_Current}{DateOfBirthToString(Model.ModelBank_Account._UserBank.DateOfBirth)}");
            Model.ModelBank_Account._UserBank.DateOfBirth = Common.Edit() ? InputisValid.InputDateTime() : Model.ModelBank_Account._UserBank.DateOfBirth;

            Console.WriteLine($"{Language.Gender_Current}{Model.ModelBank_Account._UserBank.Gender}");
            Model.ModelBank_Account._UserBank.Gender = Common.Edit() ? InputisValid.InputGender() : Model.ModelBank_Account._UserBank.Gender;

            Console.WriteLine($"{Language.CMND_CCCD_Current}{Model.ModelBank_Account._UserBank.CMND_CCCD}");
            Model.ModelBank_Account._UserBank.CMND_CCCD = Common.Edit() ? InputisValid.InputCMND_CCCD() : Model.ModelBank_Account._UserBank.CMND_CCCD;

            Console.WriteLine($"{Language.Address_Current}{Model.ModelBank_Account._UserBank.Address}");
            Model.ModelBank_Account._UserBank.Address = Common.Edit() ? InputisValid.InputAddress() : Model.ModelBank_Account._UserBank.Address;

            Console.WriteLine($"{Language.Email_Current}{Model.ModelBank_Account._UserBank.Email}");
            Model.ModelBank_Account._UserBank.Email = Common.Edit() ? InputisValid.InputValidEmail() : Model.ModelBank_Account._UserBank.Email;

            Console.WriteLine($"{Language.SDT_Current}{Model.ModelBank_Account._UserBank.Phone}");
            Model.ModelBank_Account._UserBank.Phone = Common.Edit() ? InputisValid.InputPhoneNumber() : Model.ModelBank_Account._UserBank.Phone;

            if (Model.ModelUser.Update_Information(Model.ModelBank_Account._UserBank.ID_User, Model.ModelBank_Account._UserBank.FullName, Model.ModelBank_Account._UserBank.DateOfBirth,Model.ModelBank_Account._UserBank.Gender, Model.ModelBank_Account._UserBank.CMND_CCCD, Model.ModelBank_Account._UserBank.Address,Model.ModelBank_Account._UserBank.Email, Model.ModelBank_Account._UserBank.Phone))
            {
                Common.PrintMessage_Console(Language.Update_Information_Success, true);
            }
            else
            {
                Common.PrintMessage_Console(Language.Update_Information_Error, false);
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
            table.AddRow($"{ControllerBank_User.UserBank.FullName}", $"{DateOfBirthToString(ControllerBank_User.UserBank.DateOfBirth)}",
                $"{ControllerBank_User.UserBank.Gender}", $"{ControllerBank_User.UserBank.CMND_CCCD}",
                $"{ControllerBank_User.UserBank.Number_Bank}", $"{ControllerBank_User.UserBank.Balance}", $"{ControllerBank_User.UserBank.Address}",
                $"{ControllerBank_User.UserBank.Email}", $"{ControllerBank_User.UserBank.Phone}");
            AnsiConsole.Write(table);
            table.Rows.Clear();
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }      
    }
}
