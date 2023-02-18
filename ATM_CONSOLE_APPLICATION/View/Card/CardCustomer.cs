﻿using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Model;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Card
{
    public class CardCustomer : AbstractCard
    {
        private static CardCustomer? _cardCustomer;

        private CardCustomer()
        {

        }
        public static CardCustomer _CardCustomer
        {
            get
            {
                if (_cardCustomer == null)
                {
                    _cardCustomer = new CardCustomer();
                }
                return _cardCustomer;
            }
        }
        public override void Card_Management()
        {
            if (ControllerBank_User.UserBank.role.Equals("customer"))
            {
                ModelCard.GetCard(ControllerBank_User.UserBank.ID_Bank);
                if (ControllerCard.Card == null)
                {
                    Common.PrintMessage_Console(Language.No_CardYet, true);
                    if (Common.CreatedCard())
                    {
                        CreateCrad();
                    }
                }
                else
                {
                    TableCard();
                }
            }
            else if (ControllerBank_User.UserBank.role.Equals("admin"))
            {
                ModelCard.GetListCard();
            }
        }
        public override void TableCard()
        {
            Table table = new Table();
            table.Border(TableBorder.AsciiDoubleHead);
            table.Expand();
            table.AddColumn("[springgreen2_1]Số Thẻ ATM[/]");
            table.AddColumn("[springgreen2_1]Loại Thẻ[/]");
            table.AddColumn("[springgreen2_1]CVV[/]");
            table.AddColumn("[springgreen2_1]Ngày Tạo Thẻ[/]");
            table.AddColumn("[springgreen2_1]Ngày Hết Hạn[/]");
            table.AddRow($"{ControllerCard.Card.Number_Card}", $"{ControllerCard.Card.Card_Type}",$"{ControllerCard.Card.CVV}", $"{DateOfBirthToString(ControllerCard.Card.Created_at_Card)}", $"{DateOfBirthToString(ControllerCard.Card.Expiration_Date)}");
            AnsiConsole.Write(table);
            table.Rows.Clear();
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
        public void CreateCrad()
        {
            string CardType = InputCardType();
            if (ControllerCard.CreateCard(CardType))
            {
                Common.PrintMessage_Console(Language.Created_Card_Success, true);
            }
            else
            {
                Console.WriteLine(Language.Error_Create_Card, false);
            }
        }
        private string InputCardType()
        {
            do
            {
                Console.Write(Language.Input_Card_Type);
                string CardType = Console.ReadLine();
                if (CardType.ToLower().Equals("napas") || CardType.ToLower().Equals("visa") || CardType.ToLower().Equals(""))
                {
                    return CardType;
                }
            } while (true);
        }
    }
}