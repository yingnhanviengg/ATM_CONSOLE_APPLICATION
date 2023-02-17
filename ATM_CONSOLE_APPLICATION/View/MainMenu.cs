﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.View.Menu;

namespace ATM_CONSOLE_APPLICATION.View
{
    public class MainMenu
    {
        public MainMenu()
        {

        }
        public bool MenuLogin()
        {
            bool result = false;
            Login_Register.Login_Register login_Register = Login_Register.Login_Register._Login_Register;
            do
            {
                Console.WriteLine("1: " + Language.Login);
                Console.WriteLine("2: " + Language.Register);
                switch (Common.Choose())
                {
                    case 1:
                        Console.Clear();
                        result = login_Register.Login();
                        break;
                    case 2:
                        Console.Clear();
                        login_Register.Register();
                        break;
                    default:
                        Common.PrintMessage_Console(Language.Exception_choose_switch, false);
                        break;
                }
            } while (!result);
            return result;
        }
        public void ShowMainMenu()
        {
            AbstractMenu Menu;
            Language._Change_Language();
            Console.Clear();
            if (MenuLogin())
            {
                if (ControllerBank_User.User.role.Equals("customer"))
                {
                    Menu = new MenuCustomer();
                    Menu.ShowMenu();
                }
                if (ControllerBank_User.User.role.Equals("admin"))
                {
                    Menu = new MenuAdmin();
                    Menu.ShowMenu();
                }
            }
        }       
    }
}
