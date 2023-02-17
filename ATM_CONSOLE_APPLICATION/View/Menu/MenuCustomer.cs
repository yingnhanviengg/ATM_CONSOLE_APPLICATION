using ATM_CONSOLE_APPLICATION.View.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Menu
{
    public class MenuCustomer : AbstractMenu
    {
        public override void Menu()
        {
            string[] Menu_Customer = { Language.Check_Account_Information, Language.Card_Management, Language.Withdraw_Money, Language.Recharge, Language.Tranfer_Money, Language.Bank_Deposit, Language.Transaction_History, Language.Change_Language };
            for (int i = 0; i < Menu_Customer.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu_Customer[i]}");
            }
        }
        public override void ShowMenu()
        {
            do
            {
                Menu();
                switch (Common.Choose())
                {
                    case 1:
                        Console.Clear();
                        Information.InformationCustomer customer = InformationCustomer._InformationCustomer;
                        customer.Information_Manager();
                        break;
                    case 2:
                        Console.Clear();
                        Card.CardCustomer cardCustomer = Card.CardCustomer._CardCustomer;
                        cardCustomer.Card_Management();
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

                        break;
                    default:
                        Console.WriteLine(Language.Exception_choose_switch);
                        break;
                }
            } while (true);
        }
    }
}
