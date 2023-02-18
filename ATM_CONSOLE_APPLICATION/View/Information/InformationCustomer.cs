﻿using ATM_CONSOLE_APPLICATION.Controller;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Table = Spectre.Console.Table;

namespace ATM_CONSOLE_APPLICATION.View.Information
{
    public class InformationCustomer : AbstractInformation
    {
        private static InformationCustomer? _informationCustomer;

        private InformationCustomer()
        {
            
        }
        public static InformationCustomer _InformationCustomer
        {
            get
            {
                if (_informationCustomer == null)
                {
                    _informationCustomer = new InformationCustomer();
                }
                return _informationCustomer;
            }           
        }
        public override void Information_Manager()
        {         
            do
            {
                Information_Manager_Menu();
                switch (Common.Choose())
                {
                    case 1:
                        Console.Clear();
                        Table_Informatio();
                        break;
                    case 2:
                        Console.Clear();
                        Update_Information();
                        break;
                    case 3:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        public override void Information_Manager_Menu()
        {
            string[] Menu_Customer = { Language.Check_Account_Information,  Language.Update_Information };
            for (int i = 0; i < Menu_Customer.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu_Customer[i]}");
            }
        }
        public override void Update_Information()
        {
            Table_Informatio();
            Console.WriteLine($"{Language.Name_Current}{ControllerBank_User.UserBank.FullName}");
            string fullname = Common.Edit() ? InputisValid.InputFullName() : ControllerBank_User.UserBank.FullName;

            Console.WriteLine($"{Language.DateOfBirth_Current}{DateOfBirthToString(ControllerBank_User.UserBank.DateOfBirth)}");
            DateTime dateofbirth = Common.Edit() ? InputisValid.InputDateTime() : ControllerBank_User.UserBank.DateOfBirth;

            Console.WriteLine($"{Language.Gender_Current}{ControllerBank_User.UserBank.Gender}");
            string gender = Common.Edit() ? InputisValid.InputGender() : ControllerBank_User.UserBank.Gender;

            Console.WriteLine($"{Language.CMND_CCCD_Current}{ControllerBank_User.UserBank.CMND_CCCD}");
            string cmnd_cccd = Common.Edit() ? InputisValid.InputCMND_CCCD() : ControllerBank_User.UserBank.CMND_CCCD;

            Console.WriteLine($"{Language.Address_Current}{ControllerBank_User.UserBank.Address}");
            string address = Common.Edit() ? InputisValid.InputAddress() : ControllerBank_User.UserBank.Address;

            Console.WriteLine($"{Language.Email_Current}{ControllerBank_User.UserBank.Email}");
            string email = Common.Edit() ? InputisValid.InputValidEmail() : ControllerBank_User.UserBank.Email;

            Console.WriteLine($"{Language.SDT_Current}{ControllerBank_User.UserBank.Phone}");
            string phone = Common.Edit() ? InputisValid.InputPhoneNumber() : ControllerBank_User.UserBank.Phone;

            ControllerBank_User controllerBank_User = ControllerBank_User.ControllerUser;

            if (controllerBank_User.Upate_Information(new Model.ModelBank_Account(ControllerBank_User.UserBank.ID_User, fullname, dateofbirth, gender, cmnd_cccd, address, user: string.Empty, pass: string.Empty, email, phone, number_bank: string.Empty)))
            {              
                Common.PrintMessage_Console(Language.Update_Information_Success, true);
            }
            else
            {
                Common.PrintMessage_Console(Language.Update_Information_Error, false);
            }
        }
        public override void Table_Informatio()
        {
            Table table = new Table();
            table.Border(TableBorder.AsciiDoubleHead);
            table.Expand();
            table.AddColumn("[springgreen2_1]Họ Và Tên[/]");
            table.AddColumn("[springgreen2_1]Ngày/Tháng/Năm Sinh[/]");
            table.AddColumn("[springgreen2_1]Giới Tính[/]");
            table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
            table.AddColumn("[springgreen2_1]Số Tài Khoản[/]");
            table.AddColumn("[springgreen2_1]Số Dư[/]");
            table.AddColumn("[springgreen2_1]Địa Chỉ[/]");
            table.AddColumn("[springgreen2_1]Email[/]");
            table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
            table.AddRow($"{ControllerBank_User.UserBank.FullName}", $"{DateOfBirthToString(ControllerBank_User.UserBank.DateOfBirth)}",
                $"{ControllerBank_User.UserBank.Gender}", $"{ControllerBank_User.UserBank.CMND_CCCD}",
                $"{ControllerBank_User.UserBank.Number_Bank}", $"{ControllerBank_User.UserBank.Balance}", $"{ControllerBank_User.UserBank.Address}",
                $"{ControllerBank_User.UserBank.Email}", $"{ControllerBank_User.UserBank.Phone}");
            AnsiConsole.Write(table);
            table.Rows.Clear();
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }      
    }
}