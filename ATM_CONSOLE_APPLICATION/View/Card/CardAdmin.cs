using ATM_CONSOLE_APPLICATION.Controller;
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
        public override void Card_Management()
        {

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
                table.AddColumn("[springgreen2_1]Loại Thẻ[/]");
                table.AddColumn("[springgreen2_1]CVV[/]");
                table.AddColumn("[springgreen2_1]Ngày Tạo Thẻ[/]");
                table.AddColumn("[springgreen2_1]Ngày Hết Hạn[/]");
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
                        table.AddRow($"{item.Number_Card}", $"{item.Card_Type}", $"{item.CVV}", $"{DateOfBirthToString(item.Created_at_Card)}", $"{DateOfBirthToString(item.Expiration_Date)}");
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
