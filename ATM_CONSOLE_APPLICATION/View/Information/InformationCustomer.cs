using ATM_CONSOLE_APPLICATION.Controller;
using Spectre.Console;
using Table = Spectre.Console.Table;

namespace ATM_CONSOLE_APPLICATION.View.Information
{
    public class InformationCustomer : AbstractInformation
    {
        private InformationCustomer()
        {

        }
        private static InformationCustomer? _informationCustomer;
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
            string[] Menu_Customer = { Language.AbstractLanguage.Check_Account_Information, Language.AbstractLanguage.Update_Information, Language.AbstractLanguage.BackMenu };
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
                        Console.Clear();
                        Table_Informatio();
                        break;
                    case 1:
                        Console.Clear();
                        Update_Information();
                        break;
                    case 2:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                }
            } while (true);
        }
        public override void Update_Information()
        {
            Table_Informatio();
            Console.WriteLine($"{Language.AbstractLanguage.Name_Current}{ControllerBank_User.UserBank.User.FullName}");
            string fullname = Common.Edit() ? InputisValid.InputFullName() : ControllerBank_User.UserBank.User.FullName;

            Console.WriteLine($"{Language.AbstractLanguage.DateOfBirth_Current}{DateOfBirthToString(ControllerBank_User.UserBank.User.DateOfBirth)}");
            DateTime dateofbirth = Common.Edit() ? InputisValid.InputDateTime() : ControllerBank_User.UserBank.User.DateOfBirth;

            Console.WriteLine($"{Language.AbstractLanguage.Gender_Current}{ControllerBank_User.UserBank.User.Gender}");
            string gender = Common.Edit() ? InputisValid.InputGender() : ControllerBank_User.UserBank.User.Gender;

            Console.WriteLine($"{Language.AbstractLanguage.CMND_CCCD_Current}{ControllerBank_User.UserBank.User.CMND_CCCD}");
            string cmnd_cccd = Common.Edit() ? InputisValid.InputCMND_CCCD() : ControllerBank_User.UserBank.User.CMND_CCCD;

            Console.WriteLine($"{Language.AbstractLanguage.Address_Current}{ControllerBank_User.UserBank.User.Address}");
            string address = Common.Edit() ? InputisValid.InputAddress() : ControllerBank_User.UserBank.User.Address;

            Console.WriteLine($"{Language.AbstractLanguage.Email_Current}{ControllerBank_User.UserBank.User.Email}");
            string email = Common.Edit() ? InputisValid.InputValidEmail() : ControllerBank_User.UserBank.User.Email;

            Console.WriteLine($"{Language.AbstractLanguage.SDT_Current}{ControllerBank_User.UserBank.User.Phone}");
            string phone = Common.Edit() ? InputisValid.InputPhoneNumber() : ControllerBank_User.UserBank.User.Phone;

            ControllderUser controllderUser = ControllderUser.__ControllerUser;
            switch (controllderUser.IsValidUpdate(ControllderUser.User.ID_User, cmnd_cccd, email, phone))
            {
                case 1:
                    if (controllderUser.Upate_Information(ControllderUser.User.ID_User, fullname, dateofbirth, gender, cmnd_cccd, address, email, phone))
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
            table.AddRow($"{ControllerBank_User.UserBank.User.FullName}", $"{DateOfBirthToString(ControllerBank_User.UserBank.User.DateOfBirth)}",
                $"{ControllerBank_User.UserBank.User.Gender}", $"{ControllerBank_User.UserBank.User.CMND_CCCD}",
                $"{ControllerBank_User.UserBank.Number_Bank}", $"{ControllerBank_User.UserBank.Balance}", $"{ControllerBank_User.UserBank.User.Address}",
                $"{ControllerBank_User.UserBank.User.Email}", $"{ControllerBank_User.UserBank.User.Phone}");
            AnsiConsole.Write(table);
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
