using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Menu
{
    public class MenuAdmin : AbstractMenu
    {
        public override void Menu()
        {
            if (AbstractLanguage.Current_Language.Equals("Vietnamese"))
            {
                Information_Manager = "Quản lý tài khoản khách hàng";
                Card_Manager = "Kiểm tra thẻ ATM khách hàng";
                Recharge_Manager = "Kiểm tra yêu cầu nạp tiền";
                Transaction_History_Manager = "Lịch sử giao dịch";
            }
            else
            {
                // menu admin english
                Information_Manager = "Quản lý tài khoản khách hàng";
                Card_Manager = "Kiểm tra thẻ ATM khách hàng";
                Recharge_Manager = "Kiểm tra yêu cầu nạp tiền";
                Transaction_History_Manager = "Lịch sử giao dịch";
            }
            string[] Menu_Admin = { Information_Manager, Card_Manager, Recharge_Manager, Tranfer_Money_Manager, AbstractLanguage.Change_Language };
            for (int i = 0; i < Menu_Admin.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu_Admin[i]}");
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
                        InformationAdmin admin = InformationAdmin._InformationAdmin;
                        admin.Information_Manager();
                        break;
                    case 2:
                        Console.Clear();
                        Card.CardAdmin cardAdmin = Card.CardAdmin._CardAdmin;
                        cardAdmin.Card_Management();
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
