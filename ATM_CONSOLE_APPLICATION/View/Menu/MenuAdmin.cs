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
            string[] Menu_Admin = { Language.Check_Account_Information_Admin, Language.Transaction_History_Admin, Language.Transaction_Statistics };
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
                        admin.Table_Informatio();
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
                        Console.WriteLine(Language.Exception_choose_switch);
                        break;
                }
            } while (true);
        }
    }
}
