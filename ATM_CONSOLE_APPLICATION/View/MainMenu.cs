﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.Model;
using ATM_CONSOLE_APPLICATION.View.Menu;
using static ATM_CONSOLE_APPLICATION.Language.VietNamese;

namespace ATM_CONSOLE_APPLICATION.View
{
    public class MainMenu
    {
        public MainMenu()
        {
            
        }
        private static AbstractMenu _menu;
        public static AbstractMenu Menu
        {
            get
            {
                if (_menu == null)
                {
                    if (ControllerBank_User.UserBank.User.role.Equals("customer"))
                    {
                        _menu = new MenuCustomer();
                    }
                    if (ControllerBank_User.UserBank.User.role.Equals("admin"))
                    {
                        _menu = new MenuAdmin();
                    }
                }
                return _menu;
            }
        }
        public bool MenuLogin()
        {
            bool result = false;
            Login_Register.Login_Register login_Register = Login_Register.Login_Register._Login_Register;
            do
            {
                Console.WriteLine("1: " + Language.AbstractLanguage.Login);
                Console.WriteLine("2: " + Language.AbstractLanguage.Register);
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
                        Common.PrintMessage_Console(Language.AbstractLanguage.Exception_choose_switch, false);
                        break;
                }
            } while (!result);
            return result;
        }
        public void ShowMainMenu()
        {
            ChangeLanguage.Change_Language();
            Console.Clear();
            if (MenuLogin())
            {
                if (ControllerBank_User.UserBank.User.role.Equals("customer"))
                {
                    Menu.ShowMenu();
                }
                if (ControllerBank_User.UserBank.User.role.Equals("admin"))
                {
                    Menu.ShowMenu();
                }
            }
        }       
    }
}
