using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Information;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Card
{
    public class CardAdmin : AbstractCard
    {
        private static CardAdmin? _cardAdmin;
        private CardAdmin()
        {

        }
        public static CardAdmin _CardAdmin
        {
            get
            {
                if (_cardAdmin == null)
                {
                    _cardAdmin = new CardAdmin();
                }
                return _cardAdmin;
            }
        }
        private ControllerCard controllerCard = ControllerCard.controllerCard;
        public void Card_Management_Menu()
        {
            string[] Menu = {AbstractLanguage.Show_All_Card, AbstractLanguage.Lock_Card, AbstractLanguage.UnLock_Card};
            for (int i = 0; i < Menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {Menu[i]}");
            }
        }
        public override void Card_Management()
        {
            do
            {
                Card_Management_Menu();
                switch (Common.Choose())
                {
                    case 1:
                        TableCard();
                        break;
                    case 2:
                        LockCard();
                        break;
                    case 3:
                        UnLockCard();
                        break;
                    default:
                        Common.PrintMessage_Console(Language.AbstractLanguage.Exception_choose_switch, false);
                        break;
                }             
            } while (true);
        }
        public void UnLockCard()
        {
            TableCard();
            string card = InputisValid.InputNumberCarb();
            var item = ControllerCard.ListCard.FirstOrDefault(x => x.Number_Card.Equals(card));
            if (item != default && controllerCard.UnLockCard(item))
            {

                Common.PrintMessage_Console(AbstractLanguage.UnLock_Card_Success, true);
            }
            else
            {
                Common.PrintMessage_Console(AbstractLanguage.UnLock_Card_Error, false);
            }
        }
        public void LockCard()
        {
            TableCard();    
            string card = InputisValid.InputNumberCarb();
            var item = ControllerCard.ListCard.FirstOrDefault(x => x.Number_Card.Equals(card));
            if (item != default && controllerCard.LockCard(item))
            {

                Common.PrintMessage_Console(AbstractLanguage.Lock_Card_Success,true);            }
            else
            {
                Common.PrintMessage_Console(AbstractLanguage.Lock_Card_Error, false);
            }
        }
        public override void TableCard()
        {
            int pageNumber = 1;
            int pageCount = (ControllerCard.ListCard.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerCard.ListCard.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"Số thẻ hiển thị {pageCount} trang, {ControllerCard.ListCard.Count} thẻ ");
                        Console.Write("Nhập số trang: ");
                        pageNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Nhập sai định dạng");
                    }
                }
            }
            if (ControllerCard.ListCard.Count == 0)
            {
                Console.WriteLine("Ko có dữ liệu");
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn("[springgreen2_1]Số Thẻ ATM[/]");
                table.AddColumn("[springgreen2_1]Mật Khẩu[/]");
                table.AddColumn("[springgreen2_1]Ngày Tạo Thẻ[/]");
                table.AddColumn("[springgreen2_1]Ngày Hết Hạn[/]");
                table.AddColumn("[springgreen2_1]Trạng Thái Thẻ[/]");
                table.AddColumn("[springgreen2_1]Tên Khách Hàng[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn("[springgreen2_1]Số Điện Thoại[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine("Số trang không hợp lệ.");
                    return;
                }
                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerCard.ListCard.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"{item.Number_Card}", $"{item.Pass_Card}", $"{DateOfBirthToString(item.Created_at_Card)}", $"{DateOfBirthToString(item.Expiration_Date)}", $"{item.Status_Card}", $"{item.UserBank.User.FullName}", $"{item.UserBank.User.CMND_CCCD}", $"{item.UserBank.User.Email}", $"{item.UserBank.User.Phone}");
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"Trang {pageNumber}/{pageCount}");
                table.Rows.Clear();
            }
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
