using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Model;
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
        public override void Information_Manager_Menu()
        {
            string[] Menu_Customer = { Language.Check_Account_Information, Language.Update_Information };
            for (int i = 0; i < Menu_Customer.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu_Customer[i]}");
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
        public ModelBank_Account SearchUserByID(int id, List<ModelBank_Account> List)
        {
            int minIndex = 0;
            int maxIndex = List.Count - 1;
            while (minIndex <= maxIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;
                var item = List[midIndex];

                if (item.ID_User < id)
                {
                    minIndex = midIndex + 1;
                }
                else if (item.ID_User > id)
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    return item;
                }
            }
            return null;
        }
        public override void Update_Information()
        {
            Table_Informatio();
            int id = InputisValid.InputIDUser();
            var item = SearchUserByID(id, ControllerBank_User.ListBank_User);
            if (item != null)
            {
                Console.WriteLine($"{Language.Name_Current}{item.FullName}");
                string fullname = Common.Edit() ? InputisValid.InputFullName() : item.FullName;

                Console.WriteLine($"{Language.DateOfBirth_Current}{DateOfBirthToString(item.DateOfBirth)}");
                DateTime dateofbirth = Common.Edit() ? InputisValid.InputDateTime() : item.DateOfBirth;

                Console.WriteLine($"{Language.Gender_Current}{item.Gender}");
                string gender = Common.Edit() ? InputisValid.InputGender() : item.Gender;

                Console.WriteLine($"{Language.CMND_CCCD_Current}{item.CMND_CCCD}");
                string cmnd_cccd = Common.Edit() ? InputisValid.InputCMND_CCCD() : item.CMND_CCCD;

                Console.WriteLine($"{Language.Address_Current}{item.Address}");
                string address = Common.Edit() ? InputisValid.InputAddress() : item.Address;

                Console.WriteLine($"{Language.Email_Current}{item.Email}");
                string email = Common.Edit() ? InputisValid.InputValidEmail() : item.Email;

                Console.WriteLine($"{Language.SDT_Current}{item.Phone}");
                string phone = Common.Edit() ? InputisValid.InputPhoneNumber() : item.Phone;

                ControllerBank_User controllerBank_User = ControllerBank_User.ControllerUser;

                if (controllerBank_User.Upate_Information(new Model.ModelBank_Account(id, fullname, dateofbirth, gender, cmnd_cccd, address, email, phone)))
                {
                    Common.PrintMessage_Console(Language.Update_Information_Success, true);
                }
                else
                {
                    Common.PrintMessage_Console(Language.Update_Information_Error, false);
                }
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
                table.AddColumn("[springgreen2_1]ID Khách Hàng[/]");
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
                        table.AddRow($"{item.ID_User}", $"{item.FullName}", $"{DateOfBirthToString(item.DateOfBirth)}",$"{item.Gender}", $"{item.CMND_CCCD}",$"{item.Number_Bank}", $"{item.Balance}", $"{item.Address}",$"{item.Email}", $"{item.Phone}");
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
