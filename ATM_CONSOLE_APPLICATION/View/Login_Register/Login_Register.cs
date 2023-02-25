using ATM_CONSOLE_APPLICATION.Controller;

namespace ATM_CONSOLE_APPLICATION.View.Login_Register
{
    public class Login_Register : ILogin_Register
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
        private ControllerBank_User ControllerUser = ControllerBank_User.ControllerUser;
        public bool Login()
        {
            string user = InputisValid.InptUsername();
            string pass = InputisValid.InputPassword();
            Console.Clear();
            switch (ControllerUser.IsLoggedIn(user, pass))
            {
                case 1:
                    Common.PrintMessage_Console(Language.AbstractLanguage.Notification_Login_True, true);
                    return true;
                case -1:
                    Common.PrintMessage_Console(Language.AbstractLanguage.Account_Is_Locked, false);
                    return false;
                default:
                    Common.PrintMessage_Console(Language.AbstractLanguage.Notification_Login_Fasle, false);
                    return false;
            }
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
