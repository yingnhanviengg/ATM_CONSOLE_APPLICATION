using ATM_CONSOLE_APPLICATION.Controller;
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
        private ControllerCard controllerCard = ControllerCard.controllerCard;
        public override void Card_Management()
        {
            if (!controllerCard.GetCard())
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.No_CardYet, true);
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
        public override void TableCard()
        {
            Table table = new Table();
            table.Border(TableBorder.AsciiDoubleHead);
            table.Expand();
            table.AddColumn("[springgreen2_1]Số Thẻ ATM[/]");
            table.AddColumn("[springgreen2_1]Mật Khẩu[/]");
            table.AddColumn("[springgreen2_1]Ngày Tạo Thẻ[/]");
            table.AddColumn("[springgreen2_1]Ngày Hết Hạn[/]");
            table.AddColumn("[springgreen2_1]Trạng Thái Thẻ[/]");
            table.AddRow($"{ControllerCard.Card.Number_Card}", $"{ControllerCard.Card.Pass_Card}", $"{DateOfBirthToString(ControllerCard.Card.Created_at_Card)}", $"{DateOfBirthToString(ControllerCard.Card.Expiration_Date)}", $"{ControllerCard.Card.Status_Card}");
            AnsiConsole.Write(table);
            table.Rows.Clear();
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
        public void CreateCrad()
        {
            if (controllerCard.CreateCard())
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.Created_Card_Success, true);
            }
            else
            {
                Console.WriteLine(Language.AbstractLanguage.Error_Create_Card, false);
            }
        }
    }
}
