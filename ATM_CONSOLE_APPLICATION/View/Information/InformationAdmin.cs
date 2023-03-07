using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Information
{
    public class InformationAdmin : AbstractInformation
    {
        ControllderUser controllderUser = ControllderUser.__ControllerUser;
        private static InformationAdmin? _informationAdmin;
        private InformationAdmin() { }
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
        public override void Information_Manager()
        {
            string[] Menu_Customer = { Language.AbstractLanguage.Check_Account_Information, Language.AbstractLanguage.Update_Information, AbstractLanguage.Lock_account, AbstractLanguage.unLock_account, Language.AbstractLanguage.BackMenu };
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
                        Lock_Account();
                        break;
                    case 3:
                        Console.Clear();
                        Unlock_Account();
                        break;
                    case 4:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                }
            } while (true);
        }
        public void Unlock_Account()
        {
            Table_Informatio();
            int id = InputisValid.InputIDUser();
            if (controllderUser.Unlock_Account(id))
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.Lock_Account_Success, true);
            }
            else { Common.PrintMessage_Console(Language.AbstractLanguage.NotFind_ID, false); }
        }
        public void Lock_Account()
        {
            Table_Informatio();
            int id = InputisValid.InputIDUser();
            if (controllderUser.Lock_Account(id))
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.Lock_Account_Success, true);
            }
            else { Common.PrintMessage_Console(Language.AbstractLanguage.NotFind_ID, false); }
        }
        public override void Update_Information()
        {
            Table_Informatio();
            int id = InputisValid.InputIDUser();
            var item = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.User.ID_User.Equals(id));
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

                switch (controllderUser.IsValidUpdate(id, cmnd_cccd, email, phone))
                {
                    case 1:
                        if (controllderUser.Upate_Information(id, fullname, dateofbirth, gender, cmnd_cccd, address, email, phone))
                        {
                            Common.PrintMessage_Console(Language.AbstractLanguage.Update_Information_Success, true);
                        }
                        else { Common.PrintMessage_Console(Language.AbstractLanguage.Update_Information_Error, false); }
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
            else { Common.PrintMessage_Console(Language.AbstractLanguage.NotFind_ID, false); }
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
                        Console.WriteLine($"{AbstractLanguage.Show} {pageCount} {AbstractLanguage.page}, {ControllerBank_User.ListBank_User.Count} {AbstractLanguage.Customer}");
                        Console.Write(AbstractLanguage.EnterPage);
                        pageNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(AbstractLanguage.ErrorFormat);
                    }
                }
            }
            if (ControllerBank_User.ListBank_User.Count == 0)
            {
                Console.WriteLine(AbstractLanguage.Nodataavailable);
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.IDcustomer}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.FullName}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Birth}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Gender}[/]");
                table.AddColumn($"[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Bankaccountnumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Balance}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Address}[/]");
                table.AddColumn($"[springgreen2_1]Email[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.PhoneNumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.status}[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine(AbstractLanguage.Invalidpagenumber);
                    return;
                }

                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerBank_User.ListBank_User.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"{item.User.ID_User}", $"{item.User.FullName}", $"{DateOfBirthToString(item.User.DateOfBirth)}", $"{item.User.Gender}", $"{item.User.CMND_CCCD}", $"{item.Number_Bank}", $"{item.Balance} VNĐ", $"{item.User.Address}", $"{item.User.Email}", $"{item.User.Phone}", $"{item.User.status_user}");
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"{AbstractLanguage.page} {pageNumber}/{pageCount}");
            }
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
