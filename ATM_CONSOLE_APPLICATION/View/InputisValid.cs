using ATM_CONSOLE_APPLICATION.Language;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View
{
    public class InputisValid
    {
        public static double InputDeposits()
        {
            while (true)
            {
                try
                {
                    Console.Write(Language.AbstractLanguage.Input_Amount_Tranfer);
                    double money = Convert.ToDouble(Console.ReadLine().Trim());
                    return money;
                }
                catch (FormatException)
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Exception_choose, false);
                }
            }
        }
        public static string InputNumberBank_Recipient()
        {
            while (true)
            {
                Console.Write(AbstractLanguage.Input_NumberBank_Recipient);
                string numberbank_recipient = Console.ReadLine();
                if (numberbank_recipient.All(char.IsDigit) && numberbank_recipient.Length == 10)
                {
                    return numberbank_recipient;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Input_NumberBank_Recipient_Error, false);
                }
            }
        }
        public static string InputNumberCarb()
        {
            while (true)
            {
                Console.Write(Language.AbstractLanguage.Input_Card);
                string card = Console.ReadLine().Trim();
                if (card.All(char.IsDigit) && card.Length == 16)
                {
                    return card;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Input_Card_Error, false);
                }
            }
        }
        public static int InputIDUser()
        {
            while (true)
            {
                try
                {
                    Console.Write(Language.AbstractLanguage.Input_IDUser);
                    int iduser = Convert.ToInt32(Console.ReadLine().Trim());
                    return iduser;
                }
                catch (FormatException)
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Exception_choose, false);
                }               
            }
        }
        public static string InputCMND_CCCD()
        {
            while (true)
            {
                Console.Write(Language.AbstractLanguage.Input_CMND_CCCD);
                string id = Console.ReadLine().Trim();
                if (id.Length == 9 || id.Length == 12)
                {
                    if (id.All(char.IsDigit))
                    {
                        return id;
                    }
                }
                Common.PrintMessage_Console(Language.AbstractLanguage.Error_Input_CMND, false);
            }
        }
        public static string InputGender()
        {
            while (true)
            {
                Console.Write(Language.AbstractLanguage.Input_Gender);
                string gender = Console.ReadLine().Trim();
                if (gender.ToLower().Equals("nam") || gender.ToLower().Equals("nữ"))
                {
                    return char.ToUpper(gender[0]) + gender.Substring(1);
                }
                Common.PrintMessage_Console(Language.AbstractLanguage.Error_Input_Gender, false);
            }
        }
        public static string InputFullName()
        {
            Console.Write(Language.AbstractLanguage.Input_Fullname);
            string fullname = Console.ReadLine();
            return fullname = StandardizeString(fullname);
        }
        public static string InputPassword()
        {
            do
            {
                Console.Write(Language.AbstractLanguage.Input_Pass);
                string pass = GetPassword();
                if (pass.Length >= 8)
                {
                    return pass;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_Input_Pass, false);
                }
            } while (true);
        }
        public static string InptUsername()
        {
            string user;
            do
            {
                Console.Write(Language.AbstractLanguage.Input_User);
                user = Console.ReadLine().Trim();
                if (IsValidUsername(user))
                {
                    return user;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_Limit_User_8_char, false);
                }
            } while (true);
        }
        public static string InputAddress()
        {
            Console.Write(Language.AbstractLanguage.Input_Address);
            string Address = Console.ReadLine();
            return Address = StandardizeString(Address);
        }
        public static string InputPhoneNumber()
        {
            string phoneNumber = string.Empty;
            bool isValidPhoneNumber = false;

            while (!isValidPhoneNumber)
            {
                Console.Write(Language.AbstractLanguage.Input_Phone);
                phoneNumber = Console.ReadLine().Trim();

                if (phoneNumber.StartsWith("0") && phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 9 && phoneNumber.Length <= 11)
                {
                    isValidPhoneNumber = true;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_Input_Phone, false);
                }
            }
            return phoneNumber;
        }
        public static string InputValidEmail()
        {
            string email;
            do
            {
                Console.Write(Language.AbstractLanguage.Input_Email);
                email = Console.ReadLine().Trim();
                if (IsValidEmail(email))
                {
                    return email;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_Input_Email, false);
                }
            } while (true);
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            Regex regex = new Regex(@"^[a-zA-Z0-9~!@#$%^&*()_\-+=\[\]{}\\|;:'"",<.>/?]+@gmail\.com$");
            return regex.IsMatch(email);
        }
        public static DateTime InputDateTime()
        {
            DateTime date;
            string inputDate;
            do
            {
                Console.Write(Language.AbstractLanguage.Input_DateOfBirth);
                inputDate = Console.ReadLine().Trim();
                if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    if (date < DateTime.MinValue || date > DateTime.MaxValue)
                    {
                        Common.PrintMessage_Console(Language.AbstractLanguage.Error_Invalid_DateOfBirth, false);
                        continue;
                    }
                    break;
                }
                else
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Error_Invalid_DateOfBirth, false);
                }
            } while (true);
            string mysqlFormattedDate = date.ToString("MM/dd/yyyy");
            if (DateTime.TryParseExact(mysqlFormattedDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.Error_Invalid_DateOfBirth, false);
                return default;
            }
        }
        public static int InputIDTransaction()
        {
            while (true)
            {
                try
                {
                    Console.Write(Language.AbstractLanguage.Input_ID_Transaction);
                    int idBank = Convert.ToInt32(Console.ReadLine().Trim());
                    return idBank;
                }
                catch (FormatException)
                {
                    Common.PrintMessage_Console(Language.AbstractLanguage.Exception_choose, false);
                }
            }
        }
        public static string StandardizeString(string str)
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
        public static string GetPassword()
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
