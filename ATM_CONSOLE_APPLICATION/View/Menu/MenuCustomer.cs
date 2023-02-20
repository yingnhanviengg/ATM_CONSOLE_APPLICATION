using ATM_CONSOLE_APPLICATION.Language;
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
            if (AbstractLanguage.Current_Language.Equals("Vietnamese"))
            {
                Information_Manager = "Thông tin tài khoản";
                Card_Manager = "Thông tin thẻ ATM";
                Withdraw_Money_Manager = "Rút tiền";
                Recharge_Manager = "Nạp tiền";
                Tranfer_Money_Manager = "Chuyển khoản";
                Bank_Deposit_Manager = "Gửi tiết kiệm";
                Transaction_History_Manager = "Lịch sử giao dịch";
            }
            else
            {
                // menu customer english
                Information_Manager = "Thông tin tài khoản";
                Card_Manager = "Thông tin thẻ ATM";
                Withdraw_Money_Manager = "Rút tiền";
                Recharge_Manager = "Nạp tiền";
                Tranfer_Money_Manager = "Chuyển khoản";
                Bank_Deposit_Manager = "Gửi tiết kiệm";
                Transaction_History_Manager = "Lịch sử giao dịch";
            }          
            string[] Menu_Customer = { Information_Manager, Card_Manager, Withdraw_Money_Manager, Recharge_Manager, Tranfer_Money_Manager, Bank_Deposit_Manager, Tranfer_Money_Manager, AbstractLanguage.Change_Language };
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
                        InformationCustomer customer = InformationCustomer._InformationCustomer;
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
                        Console.WriteLine(Language.AbstractLanguage.Exception_choose_switch);
                        break;
                }
            } while (true);
        }
    }
}
