using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Menu
{
    public abstract class AbstractMenu
    {
        public static string Card_Manager { get; set; }
        public static string Information_Manager { get; set; }
        public static string Withdraw_Money_Manager { get; set; }
        public static string Recharge_Manager { get; set; }
        public static string Tranfer_Money_Manager { get; set; }
        public static string Bank_Deposit_Manager { get; set; }
        public static string Transaction_History_Manager { get; set; }
        public abstract void Menu();
        public abstract void ShowMenu();
    }
}
