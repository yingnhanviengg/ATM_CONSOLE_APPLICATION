using System.Globalization;
using System.Text.RegularExpressions;
using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.View.Information;
using ATM_CONSOLE_APPLICATION.Controller.email;

namespace ATM_CONSOLE_APPLICATION.View.Login_Register
{
    public class Login_Register : ILogin_Register
    {
        public static Login_Register? _login_Register;

        public Login_Register()
        {

        }
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
        public ControllerBank_User ControllerUser = ControllerBank_User.ControllerUser;
        public bool Login()
        {
            string user = InputisValid.InptUsername();
            string pass = InputisValid.InputPassword();
            var login = new Model.ModelBank_Account(user, pass);
            if (user != null && pass != null)
            {
                if (ControllerUser.IsLoggedIn(login))
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Notification_Login_True, true);
                    return true;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Notification_Login_Fasle, false);
                    return false;
                }
            }
            return false;
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
            var register = new Model.ModelBank_Account(fullname, dateofbirth, gender, cmnd_cccd, address, username, password, email, phone, number_bank: string.Empty);
            int result = ControllerUser.IsRegister(register);
            switch (result)
            {
                case 1:
                    Email templateMail;
                    templateMail = new TemplateMailRegister_Code();
                    if (templateMail.Mail(register))
                    {
                        Console.Write(Language.AbstractLanguage.Enter_Code);
                        string code = Console.ReadLine().Trim();
                        if (ControllerUser.Register(code, register))
                        {
                            Common.PrintMessage_Console(Language.AbstractLanguage.Register_Success, true);
                        }
                        else
                        {
                            int cout = 3;
                            do
                            {
                                Common.PrintMessage_Console(Language.AbstractLanguage.Error_Code, false);
                                Common.PrintMessage_Console(Language.AbstractLanguage.Error_Code_Limit_3 + cout.ToString(), false);
                                Console.Write(Language.AbstractLanguage.Enter_Code);
                                code = Console.ReadLine().Trim();
                                if (ControllerUser.Register(code, register))
                                {
                                    Common.PrintMessage_Console(Language.AbstractLanguage.Register_Success, true);
                                }
                                else
                                {
                                    cout--;
                                }
                            } while (cout != 0);
                            if (cout == 0)
                            {
                                Common.PrintMessage_Console(Language.AbstractLanguage.Error_Re_register, false);
                            }
                        }
                        break;
                    }
                    else break;
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
