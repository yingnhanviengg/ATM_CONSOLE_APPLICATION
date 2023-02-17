using System.Globalization;
using System.Text.RegularExpressions;
using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.View.Information;

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
            string user = InptUsername();
            string pass = InputPassword();
            if (user != null && pass != null)
            {
                if (ControllerUser.IsLoggedIn(user, pass))
                {
                    Common.PrintMessage_Console(Language.Notification_Login_True, true);
                    return true;
                }
                else
                {
                    Common.PrintMessage_Console(Language.Notification_Login_Fasle, false);
                    return false;
                }
            }
            return false;
        }
        public void Register()
        {
            string fullname = InputFullName();
            string gender = InputGender();
            DateTime DateOfBirth = InputDateTime();
            string user = InptUsername();
            string pass = InputPassword();
            string Address = InputAddress();
            string CMND_CCCD = InputCMND_CCCD();
            string email = GetValidEmail();
            string phone = GetPhoneNumber();
            int result = ControllerUser.IsRegister(CMND_CCCD, user, email, phone);
            if (result == 1)
            {
                if (Email.Send_Mail_Register(email, fullname))
                {
                    Console.Write(Language.Enter_Code);
                    string code = Console.ReadLine().Trim();
                    if (ControllerUser.Register(code, fullname, gender, DateOfBirth, Address, CMND_CCCD, user, pass, email, phone))
                    {
                        Common.PrintMessage_Console(Language.Register_Success, true);
                    }
                    else
                    {
                        int cout = 3;
                        do
                        {
                            Common.PrintMessage_Console(Language.Error_Code, false);
                            Common.PrintMessage_Console(Language.Error_Code_Limit_3 + cout.ToString(), false);
                            Console.Write(Language.Enter_Code);
                            code = Console.ReadLine().Trim();
                            if (ControllerUser.Register(code, fullname, gender, DateOfBirth, Address, CMND_CCCD, user, pass, email, phone))
                            {
                                Common.PrintMessage_Console(Language.Register_Success, true);
                                break;
                            }
                            else
                            {
                                cout--;
                            }
                        } while (cout != 0);
                        if (cout == 0)
                        {
                            Common.PrintMessage_Console(Language.Error_Re_register, false);
                        }
                    }
                }
            }
            else if (result == -1)
            {
                Common.PrintMessage_Console(Language.Error_User_Already_Exists + "\n" + Language.Registration_Failed, false);
            }
            else if (result == -2)
            {
                Common.PrintMessage_Console(Language.Error_Email_Already_Exists + "\n" + Language.Registration_Failed, false);
            }
            else if (result == -3)
            {
                Common.PrintMessage_Console(Language.Error_Phone_Already_Exists + "\n" + Language.Registration_Failed, false);
            }
            else if (result == -4)
            {
                Common.PrintMessage_Console(Language.Error_CNMD_CCCD_Already_Exists + "\n" + Language.Registration_Failed, false);
            }
        }
        public string InputCMND_CCCD()
        {
            while (true)
            {
                Console.Write(Language.Input_CMND_CCCD);
                string id = Console.ReadLine().Trim();
                if (id.Length == 9 || id.Length == 12)
                {
                    if (id.All(char.IsDigit))
                    {
                        return id;
                    }
                }
                Common.PrintMessage_Console(Language.Error_Input_CMND, false);
            }
        }
        public string InputGender()
        {
            while (true)
            {
                Console.Write(Language.Input_Gender);
                string gender = Console.ReadLine().Trim();
                if (gender.ToLower().Equals("nam") || gender.ToLower().Equals("nữ"))
                {
                    return char.ToUpper(gender[0]) + gender.Substring(1);
                }
                Common.PrintMessage_Console(Language.Error_Input_Gender, false);
            }
        }
        public string InputFullName()
        {
            Console.Write(Language.Input_Fullname);
            string fullname = Console.ReadLine();
            return fullname = StandardizeString(fullname);
        }
        public string InputPassword()
        {
            do
            {
                Console.Write(Language.Input_Pass);
                string pass = GetPassword();
                if (pass.Length >= 8)
                {
                    return pass;
                }
                else
                {
                    Common.PrintMessage_Console(Language.Error_Input_Pass, false);
                }
            } while (true);
        }
        public string InptUsername()
        {
            string user;
            do
            {
                Console.Write(Language.Input_User);
                user = Console.ReadLine().Trim();
                if (IsValidUsername(user))
                {
                    return user;
                }
                else
                {
                    Common.PrintMessage_Console(Language.Error_Limit_User_8_char, false);
                }
            } while (true);
        }
        public string InputAddress()
        {
            Console.Write(Language.Input_Address);
            string Address = Console.ReadLine();
            return Address = StandardizeString(Address);
        }
        public string GetPhoneNumber()
        {
            string phoneNumber = string.Empty;
            bool isValidPhoneNumber = false;

            while (!isValidPhoneNumber)
            {
                Console.Write(Language.Input_Phone);
                phoneNumber = Console.ReadLine().Trim();

                if (phoneNumber.StartsWith("0") && phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 9 && phoneNumber.Length <= 11)
                {
                    isValidPhoneNumber = true;
                }
                else
                {
                    Common.PrintMessage_Console(Language.Error_Input_Phone, false);
                }
            }
            return phoneNumber;
        }
        public string GetValidEmail()
        {
            string email;
            do
            {
                Console.Write(Language.Input_Email);
                email = Console.ReadLine().Trim();
                if (IsValidEmail(email))
                {
                    return email;
                }
                else
                {
                    Common.PrintMessage_Console(Language.Error_Input_Email, false);
                }
            } while (true);
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            Regex regex = new Regex(@"^[a-zA-Z0-9~!@#$%^&*()_\-+=\[\]{}\\|;:'"",<.>/?]+@gmail\.com$");
            return regex.IsMatch(email);
        }
        public DateTime InputDateTime()
        {
            DateTime date;
            string inputDate;
            do
            {
                Console.Write(Language.Input_DateOfBirth);
                inputDate = Console.ReadLine().Trim();
                if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    if (date < DateTime.MinValue || date > DateTime.MaxValue)
                    {
                        Common.PrintMessage_Console(Language.Error_Invalid_DateOfBirth, false);
                        continue;
                    }
                    break;
                }
                else
                {
                    Common.PrintMessage_Console(Language.Error_Invalid_DateOfBirth, false);
                }
            } while (true);
            string mysqlFormattedDate = date.ToString("MM/dd/yyyy");
            if (DateTime.TryParseExact(mysqlFormattedDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                Common.PrintMessage_Console(Language.Error_Invalid_DateOfBirth, false);
                return default;
            }
        }
        public string StandardizeString(string str)
        {
            str = str.Trim();
            str = str.ToLower();
            while (str.Contains("  "))
            {
                str = str.Replace(" ", " ");
            }
            string[] Tach_Chuoi = str.Split(' ');
            string Ghep_Chuoi = string.Empty;
            for (int i = 0; i < Tach_Chuoi.Length; i++)
            {
                Ghep_Chuoi += Tach_Chuoi[i][..1].ToUpper() + Tach_Chuoi[i][1..] + " ";
            }
            return Ghep_Chuoi.TrimEnd();
        }
        public bool IsValidUsername(string str)
        {
            string pattern = @"^[a-zA-Z0-9]*$";
            Regex regex = new(pattern);
            return regex.IsMatch(str) && str.Length >= 8;
        }
        public string GetPassword()
        {
            string pass = string.Empty;
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
    }
}
