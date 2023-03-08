using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Card
{
    public class CardAdmin : AbstractCard
    {
        private static CardAdmin? _cardAdmin;
        private CardAdmin() { }
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
        public override void Card_Management()
        {
            string[] Menu_Customer = { AbstractLanguage.Show_All_Card, AbstractLanguage.Lock_Card, AbstractLanguage.UnLock_Card, Language.AbstractLanguage.BackMenu };
            Common.UI();
            do
            {
                var menuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                        .Title("")
                        .PageSize(10)
                        .AddChoices(Menu_Customer));
                int selectedIndex = Array.IndexOf(Menu_Customer, menuSelection);
                switch (selectedIndex)
                {
                    case 0:
                        Console.Clear();
                        TableCard();
                        break;
                    case 1:
                        Console.Clear();
                        LockCard();
                        break;
                    case 2:
                        Console.Clear();
                        UnLockCard();
                        break;
                    case 3:
                        Console.Clear();
                        MainMenu.Menu.ShowMenu();
                        break;
                }
            } while (true);
        }
        public void UnLockCard()
        {
            TableCard();
            string card = InputisValid.InputNumberCarb();
            if (controllerCard.UnLockCard(card))
            {
                Common.PrintMessage_Console(AbstractLanguage.UnLock_Card_Success, true);
            }
            else { Common.PrintMessage_Console(AbstractLanguage.UnLock_Card_Error, false); }
        }
        public void LockCard()
        {
            TableCard();
            string card = InputisValid.InputNumberCarb();
            if (controllerCard.LockCard(card))
            {

                Common.PrintMessage_Console(AbstractLanguage.Lock_Card_Success, true);
            }
            else { Common.PrintMessage_Console(AbstractLanguage.Lock_Card_Error, false); }
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
                        Console.WriteLine($"{AbstractLanguage.Show} {pageCount} {AbstractLanguage.page}, {ControllerCard.ListCard.Count} {AbstractLanguage.Card}");
                        Console.Write(AbstractLanguage.EnterPage);
                        pageNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(AbstractLanguage.ErrorFormat);
                    }
                }
            }
            if (ControllerCard.ListCard.Count == 0)
            {
                Console.WriteLine(AbstractLanguage.Nodataavailable);
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.ATMCardNumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.CardPassword}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.CardCreationDate}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.CardExpirationDate}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.CardStatus}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.FullName}[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn($"[springgreen2_1]Email[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.PhoneNumber}[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine(AbstractLanguage.Invalidpagenumber);
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
                Console.WriteLine($"{AbstractLanguage.page} {pageNumber}/{pageCount}");
            }
        }
        public override string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
