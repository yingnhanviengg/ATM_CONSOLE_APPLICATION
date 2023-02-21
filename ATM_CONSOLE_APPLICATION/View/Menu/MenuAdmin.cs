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
            string[] Menu_Admin = { AbstractLanguage.Information_Manager_Admin, AbstractLanguage.Card_Manager_Admin, AbstractLanguage.Recharge_Manager_Admin, AbstractLanguage.Transaction_History_Manager_Admin, AbstractLanguage.Change_Language };
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
                        Console.Clear();
                        Recharge.RecchargeAdmin recchargeAdmin = Recharge.RecchargeAdmin._RecchargeAdmin;
                        recchargeAdmin.Confirm_Reccharge();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine(Language.AbstractLanguage.Exception_choose_switch);
                        break;
                }
            } while (true);
        }
    }
}
