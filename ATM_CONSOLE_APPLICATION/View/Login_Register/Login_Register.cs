using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Withdraw;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Login_Register
{
    public class Login_Register
    {
        private static Login_Register? _login_Register;
        public Login_Register() { }
        public static Login_Register _Login_Register
        {
            get
            {
                if (_login_Register == null)
                {
                    _login_Register = new Login_Register();
                }
                return _login_Register;
            }
        }
        public ControllderUser ControllerUser = ControllderUser.__ControllerUser;
        public bool MenuLogin()
        {
            string[] Menu_Customer = { Language.AbstractLanguage.Login, Language.AbstractLanguage.Register, AbstractLanguage.Withdraw_Money_Customer };
            bool result = false;
            do
            {
                Common.UI();
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
                        result = Login();
                        break;
                    case 1:
                        Console.Clear();
                        Register();
                        break;
                    case 2:
                        Console.Clear();
                        VWithdraw vWithdraw = VWithdraw._Withdraw;
                        vWithdraw.Withdraw();
                        break;
                }
            } while (!result);
            return result;
        }
        public bool Login()
        {
            bool result = false;
            string user = InputisValid.InptUsername();
            int count = 5;
            if (ControllerUser.FindUser(user))
            {
                do
                {
                    string pass = InputisValid.InputPassword();
                    Console.Clear();
                    switch (ControllerUser.IsLoggedIn(user, pass))
                    {
                        case 1:
                            Common.PrintMessage_Console(Language.AbstractLanguage.Notification_Login_True, true);
                            result = true;
                            break;
                        case -1:
                            Common.PrintMessage_Console(Language.AbstractLanguage.Account_Is_Locked, false);
                            count = -1;
                            break;
                        default:
                            count--;
                            Common.PrintMessage_Console(Language.AbstractLanguage.Notification_Login_Fasle, false);
                            Common.PrintMessage_Console(count.ToString() + " " + Language.AbstractLanguage.LimitReached_Lock, false);
                            break;
                    }
                } while (count != 0 && result != true && count != -1);
                if (count == 0)
                {
                    Console.Clear();
                    ControllerUser.LockAcountLimitLogin(user);
                    Common.PrintMessage_Console(Language.AbstractLanguage.Account_HasLocked, false);
                }
            }
            else { Common.PrintMessage_Console(Language.AbstractLanguage.UserNotExist, false); }
            return result;
        }
        public void Register()
        {
            string fullname = InputisValid.InputFullName();
            string gender = InputisValid.InputGender();
            DateTime dateofbirth = InputisValid.InputDateTime();
            string username = InputisValid.InptUsername();
            string password = InputisValid.InputPassword();
            string address = InputisValid.InputAddress();
            string cmnd_cccd = InputisValid.InputCMND_CCCD();
            string email = InputisValid.InputValidEmail();
            string phone = InputisValid.InputPhoneNumber();
            int result = ControllerUser.IsRegister(cmnd_cccd, username, email, phone);
            switch (result)
            {
                case 1:
                    if (ControllerUser.Register(fullname, dateofbirth, gender, cmnd_cccd, address, username, password, email, phone))
                    {
                        Common.PrintMessage_Console(Language.AbstractLanguage.Register_Success, true);
                    }
                    else { Common.PrintMessage_Console(Language.AbstractLanguage.Error_Re_register, false); }
                    break;
                case -1:
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_User_Already_Exists + "\n" + Language.AbstractLanguage.Registration_Failed, false);
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
    }
}
