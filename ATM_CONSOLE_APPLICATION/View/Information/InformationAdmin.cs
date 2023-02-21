using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
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
        ControllerBank_User controllerBank_User = ControllerBank_User.ControllerUser;
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
            string[] Menu_Customer = { Language.AbstractLanguage.Check_Account_Information, Language.AbstractLanguage.Update_Information, AbstractLanguage.Lock_account, AbstractLanguage.unLock_account };
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
                        Lock_Account();
                        break;
                    case 4:
                        Console.Clear();
                        Unlock_Account();
                        break;
                    case 5:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                    default:
                        Common.PrintMessage_Console(Language.AbstractLanguage.Exception_choose_switch, false);
                        break;
                }
            } while (true);
        }
        public void Unlock_Account()
        {
            Table_Informatio();
            int id = InputisValid.InputIDUser();
            var item = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.User.status_user.Equals(id));
            if (item != default)
            {
                if (controllerBank_User.Unlock_Account(item))
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Lock_Account_Success, true);
                }
            }
            else
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.NotFind_ID, false);
            }
        }
        public ModelBank_Account SearchUserByID(int id, List<ModelBank_Account> List)
        {
            int minIndex = 0;
            int maxIndex = List.Count - 1;
            while (minIndex <= maxIndex)
            {
                int midIndex = (minIndex + maxIndex) / 2;
                var item = List[midIndex];

                if (item.User.ID_User < id)
                {
                    minIndex = midIndex + 1;
                }
                else if (item.User.ID_User > id)
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
        public void Lock_Account()
        {
            Table_Informatio();
            int id = InputisValid.InputIDUser();
            var item = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.User.status_user.Equals(id));
            if (item != default)
            {
                if (controllerBank_User.Lock_Account(item))
                {                 
                    Common.PrintMessage_Console(Language.AbstractLanguage.Lock_Account_Success, true);
                }
            }
            else
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.NotFind_ID, false);
            }
        }
        public override void Update_Information()
        {
            Table_Informatio();
            int id = InputisValid.InputIDUser();
            var item = SearchUserByID(id, ControllerBank_User.ListBank_User);
            if (item != null)
            {
                Console.WriteLine($"{Language.AbstractLanguage.Name_Current}{item.User.FullName}");
                string fullname = Common.Edit() ? InputisValid.InputFullName() : item.User.FullName;

                Console.WriteLine($"{Language.AbstractLanguage.DateOfBirth_Current}{DateOfBirthToString(item.User.DateOfBirth)}");
                DateTime dateofbirth = Common.Edit() ? InputisValid.InputDateTime() : item.User.DateOfBirth;

                Console.WriteLine($"{Language.AbstractLanguage.Gender_Current}{item.User.Gender}");
                string gender = Common.Edit() ? InputisValid.InputGender() : item.User.Gender;

                Console.WriteLine($"{Language.AbstractLanguage.CMND_CCCD_Current}{item.User.CMND_CCCD}");
                string cmnd_cccd = Common.Edit() ? InputisValid.InputCMND_CCCD() : item.User.CMND_CCCD;

                Console.WriteLine($"{Language.AbstractLanguage.Address_Current}{item.User.Address}");
                string address = Common.Edit() ? InputisValid.InputAddress() : item.User.Address;

                Console.WriteLine($"{Language.AbstractLanguage.Email_Current}{item.User.Email}");
                string email = Common.Edit() ? InputisValid.InputValidEmail() : item.User.Email;

                Console.WriteLine($"{Language.AbstractLanguage.SDT_Current}{item.User.Phone}");
                string phone = Common.Edit() ? InputisValid.InputPhoneNumber() : item.User.Phone;
                var user = new ModelUser(id, fullname, dateofbirth, gender, cmnd_cccd, address, email, phone);
                var update = new ModelBank_Account(user);
                switch (controllerBank_User.IsValidUpdate(update))
                {
                    case 1:
                        if (controllerBank_User.Upate_Information(update))
                        {
                            Common.PrintMessage_Console(Language.AbstractLanguage.Update_Information_Success, true);
                        }
                        else
                        {
                            Common.PrintMessage_Console(Language.AbstractLanguage.Update_Information_Error, false);
                        }
                        break;
                    case -2:
                        Common.PrintMessage_Console(Language.AbstractLanguage.Error_Email_Already_Exists + "\n" + Language.AbstractLanguage.Registration_Failed, false);
                        break;
                    case -3:
                        Common.PrintMessage_Console(Language.AbstractLanguage.Error_Phone_Already_Exists + "\n" + Language.AbstractLanguage.Registration_Failed, false);
                        break;
                    case -4:
                        Common.PrintMessage_Console(Language.AbstractLanguage.Error_CNMD_CCCD_Already_Exists + "\n" + Language.AbstractLanguage.Registration_Failed, false);
                        break;
                }         
            }
            else
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.NotFind_ID, false);
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
                        if (item.User.status_user.Equals("normal"))
                        {
                            table.AddRow($"{item.User.ID_User}", $"{item.User.FullName}", $"{DateOfBirthToString(item.User.DateOfBirth)}", $"{item.User.Gender}", $"{item.User.CMND_CCCD}", $"{item.Number_Bank}", $"{item.Balance}", $"{item.User.Address}", $"{item.User.Email}", $"{item.User.Phone}");

                        }                     
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
