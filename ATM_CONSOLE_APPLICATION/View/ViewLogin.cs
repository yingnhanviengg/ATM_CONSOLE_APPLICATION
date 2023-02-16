using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ATM_CONSOLE_APPLICATION.Controller;

namespace ATM_CONSOLE_APPLICATION.View
{
    public class ViewLogin
    {
        private static ControllerUser ControllerUser = new ControllerUser();      
        public static void Register()
        {
            string fullname = InputFullName();
            string gender = InputGender();
            DateTime DateOfBirth = ConvertToDateTime();
            string user = InptUsername();
            string pass = InputPassword();
            string Address = InputAddress();
            string CMND_CCCD = InputCMND_CCCD();
            string email = GetValidEmail();
            string phone = GetPhoneNumber();
            int result = ControllerUser.IsRegister(CMND_CCCD, user, email, phone);
            if (result == 1)
            {
                if (ControllerUser.Mail_Register(email, fullname))
                {
                    Console.Write(Language.Enter_Code);
                    string code = Console.ReadLine();
                    if (ControllerUser.Register(code, fullname, gender, DateOfBirth, Address, CMND_CCCD, user, pass, email, phone))
                    {
                        Console.WriteLine(Language.Register_Success);
                    }
                    else
                    {
                        int cout = 3;
                        do
                        {
                            Console.WriteLine(Language.Error_Code);
                            Console.WriteLine(Language.Error_Code_Limit_3 + cout);
                            Console.Write(Language.Enter_Code);
                            code = Console.ReadLine();
                            if (ControllerUser.Register(code, fullname, gender, DateOfBirth, Address, CMND_CCCD, user, pass, email, phone))
                            {
                                Console.WriteLine(Language.Register_Success);
                                break;
                            }
                            else
                            {
                                cout--;
                            }                        
                        } while (cout != 0);
                        if (cout == 0)
                        {
                            Console.WriteLine(Language.Error_Re_register);
                        }
                    }
                }              
            }
            else if(result == -1)
            {
                Console.WriteLine(Language.Error_User_Already_Exists);
                Console.WriteLine(Language.Registration_Failed);
            }
            else if (result == -2)
            {
                Console.WriteLine(Language.Error_Email_Already_Exists);
                Console.WriteLine(Language.Registration_Failed);
            }
            else if (result == -3)
            {
                Console.WriteLine(Language.Error_Phone_Already_Exists);
                Console.WriteLine(Language.Registration_Failed);
            }
            else if (result == -4)
            {
                Console.WriteLine(Language.Error_CNMD_CCCD_Already_Exists);
                Console.WriteLine(Language.Registration_Failed);
            }
        }
        private static string InputCMND_CCCD()
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
                Console.WriteLine(Language.Error_Input_CMND);
            }
        }
        private static string InputGender()
        {
            while (true)
            {
                Console.Write(Language.Input_Gender);
                string gender = Console.ReadLine().Trim();
                if (gender.ToLower().Equals("nam") || gender.ToLower().Equals("nữ"))
                {
                    return char.ToUpper(gender[0]) + gender.Substring(1);
                }
                Console.WriteLine(Language.Error_Input_Gender);
            }
        }
        private static string InputFullName()
        {
            Console.Write(Language.Input_Fullname);
            string fullname = Console.ReadLine();
            return fullname = StandardizeString(fullname);           
        }
        private static string InputPassword()
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
                    Console.WriteLine(Language.Error_Input_Pass);
                }
            } while (true);
        }
        private static string InptUsername()
        {
            string user;
            do
            {
                Console.Write(Language.Input_User);
                user = Console.ReadLine();
                if (IsValidUsername(user))
                {
                    return user;
                }
                else
                {
                    Console.WriteLine(Language.Error_Limit_User_8_char);
                }
            } while (true);
        }
        private static string InputAddress()
        {
            Console.Write(Language.Input_Address);
            string Address = Console.ReadLine();
            return Address = StandardizeString(Address);
        }
        public static bool Login()
        {
            string user = InptUsername();
            string pass = InputPassword();
            if (user != null && pass != null)
            {
                if (ControllerUser.IsLoggedIn(user, pass))
                {
                    Console.WriteLine(Language.Notification_Login_True);
                    return true;
                }
                else
                {
                    Console.WriteLine(Language.Notification_Login_Fasle);
                    return false;
                }
            }
            return false;
        }
        private static string GetPhoneNumber()
        {
            string phoneNumber = string.Empty;
            bool isValidPhoneNumber = false;

            while (!isValidPhoneNumber)
            {
                Console.Write(Language.Input_Phone);
                phoneNumber = Console.ReadLine().Trim();

                if (phoneNumber.StartsWith("0") && phoneNumber.All(char.IsDigit) && (phoneNumber.Length >= 9 && phoneNumber.Length <= 11))
                {
                    isValidPhoneNumber = true;
                }
                else
                {
                    Console.WriteLine(Language.Error_Input_Phone);
                }
            }
            return phoneNumber;
        }
        private static string GetValidEmail()
        {
            string email;
            do
            {
                Console.Write(Language.Input_Email);
                email = Console.ReadLine().Trim();
                if (!IsValidEmail(email))
                {
                    Console.WriteLine(Language.Error_Input_Email);
                }
                else
                {
                    break;
                }
            } while (true);
            return email;
        }
        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            Regex regex = new Regex(@"^[a-zA-Z0-9~!@#$%^&*()_\-+=\[\]{}\\|;:'"",<.>/?]+@gmail\.com$");
            return regex.IsMatch(email);
        }
        private static DateTime ConvertToDateTime()
        {
            DateTime date;
            string inputDate;
            do
            {
                Console.Write(Language.Input_DateOfBirth);
                inputDate = Console.ReadLine();
                if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine(Language.Error_Invalid_BateOfBirth);
                }
                else
                {
                    break;
                }
            } while (true);

            string mysqlFormattedDate = date.ToString("MM/dd/yyyy");
            if (DateTime.TryParseExact(mysqlFormattedDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                if (date < DateTime.MinValue || date > DateTime.MaxValue)
                {
                    Console.WriteLine(Language.Error_Invalid_BateOfBirth);
                    return default;
                }
                return date;
            }
            else
            {
                Console.WriteLine(Language.Error_Invalid_BateOfBirth);
                return default;
            }
        }
        private static string StandardizeString(string str)
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
        public static bool IsValidUsername(string str)
        {
            string pattern = @"^[a-zA-Z0-9]*$";
            Regex regex = new(pattern);
            return regex.IsMatch(str) && str.Length >= 8;
        }
        private static string GetPassword()
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
