using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ATM_CONSOLE_APPLICATION.Controller;

namespace ATM_CONSOLE_APPLICATION.View
{
    public sealed class MainMenu
    {       
        public MainMenu()
        {

        }
        public static void MenuCustomer()
        {
            string[] Menu_Customer = { Language.Check_Account_Information, Language.Check_Bank_Balance, Language.Withdraw_Money, Language.Recharge, Language.Tranfer_Money, Language.Bank_Deposit, Language.Transaction_History, Language.Languege };
            for (int i = 0; i < Menu_Customer.Length; i++)
            {
                Console.WriteLine($"{i+1}: {Menu_Customer[i]}");
            }
        }
        public static void MenuAdmin()
        {
            string[] Menu_Admin = {Language.Check_Account_Information_Admin, Language.Transaction_History_Admin, Language.Transaction_Statistics};
            for (int i = 0; i < Menu_Admin.Length; i++)
            {
                Console.WriteLine($"{i+1}: {Menu_Admin[i]}");
            }
        }
        public static void ShowMenuCusomer()
        {
            do
            {              
                MenuCustomer();
                switch (Common.Choose())
                {
                    case 1:
                        Information.TableInformation_User();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        Change_Language();
                        break;
                    default:
                        Console.WriteLine(Language.Exception_choose_switch);
                        break;
                }
            } while (true);
        }
        public static bool MenuLogin()
        {        
            bool result = false;
            do
            {
                Console.WriteLine("1: " + Language.Login);
                Console.WriteLine("2: " + Language.Register);
                switch (Common.Choose())
                {
                    case 1:
                        Console.Clear();
                        result = ViewLogin.Login();
                        break;
                    case 2:
                        Console.Clear();
                        ViewLogin.Register();
                        break;
                    default:
                        Console.WriteLine(Language.Exception_choose_switch);
                        break;
                }
            } while (!result);
            return result;
        }
        public static void MeinMenu()
        {
            Change_Language();
            if (MenuLogin())
            {
                if (ControllerUser.User.role.Equals("customer"))
                {
                    ShowMenuCusomer();
                }
                if (ControllerUser.User.role.Equals("admin"))
                {

                }
            }         
        }
        public static void Change_Language()
        {
            while (true)
            {
                int x;
                Console.WriteLine("1: English");
                Console.WriteLine("2: Vietnamese");
                switch (x = Common.Choose())
                {
                    case 1:
                        Language.English();
                        break;
                    case 2:
                        Language.Vietnamese();
                        break;
                    default:
                        Console.WriteLine(Language.Exception_choose_switch);
                        break;
                }
                if (x == 1 || x == 2)
                {
                    break;
                }
            }
        }
    }
}
