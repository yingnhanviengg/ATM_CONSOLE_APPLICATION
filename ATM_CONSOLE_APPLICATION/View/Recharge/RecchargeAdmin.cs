using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View.Recharge
{
    public class RecchargeAdmin : AbstractRecharge
    {
        private static RecchargeAdmin? _recchargeAdmin;
        private RecchargeAdmin() { }
        public static RecchargeAdmin _RecchargeAdmin
        {
            get
            {
                if (_recchargeAdmin == null)
                {
                    _recchargeAdmin = new RecchargeAdmin();
                }
                return _recchargeAdmin;
            }
        }
        ControllerTransaction controllerTransaction = ControllerTransaction._ControllerTransaction;
        public void Confirm_Reccharge()
        {
            Table_Recharge();
            int id_transaction = InputisValid.InputIDTransaction();
            if (Common.IsConfirm_Recharge())
            {
                if (controllerTransaction.Confirm_Reccharge(id_transaction))
                {
                    Common.PrintMessage_Console(AbstractLanguage.Confirm_Reacharge_Success, true);
                }
                else { Common.PrintMessage_Console(AbstractLanguage.NotFind_Transaction, false); }
            }
        }
        public override void Table_Recharge()
        {
            int pageNumber = 1;
            int pageCount = (ControllerTransaction.ListRequireRecharge.Count + 10 - 1) / 10;
            int pageSize = 10;
            if (ControllerTransaction.ListRequireRecharge.Count > 10)
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"{AbstractLanguage.Show} {pageCount} {AbstractLanguage.page}, {ControllerTransaction.ListRequireRecharge.Count} {AbstractLanguage.request}");
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
            if (ControllerTransaction.ListRequireRecharge.Count == 0)
            {
                Console.WriteLine(AbstractLanguage.Nodataavailable);
                return;
            }
            else
            {
                Table table = new Table();
                table.Border(TableBorder.AsciiDoubleHead);
                table.Expand();
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.TransactionID}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Bankaccountnumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.FullName}[/]");
                table.AddColumn("[springgreen2_1]CMND/CCCD[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.Balance}[/]");
                table.AddColumn("[springgreen2_1]Email[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.PhoneNumber}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.DepositAmount}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.RequestStatus}[/]");
                table.AddColumn($"[springgreen2_1]{AbstractLanguage.TimeRequired}[/]");
                if (pageNumber < 1 || pageNumber > pageCount)
                {
                    Console.WriteLine(AbstractLanguage.Invalidpagenumber);
                    return;
                }
                else
                {
                    int startIndex = (pageNumber - 1) * pageSize;
                    foreach (var item in ControllerTransaction.ListRequireRecharge.Skip(startIndex).Take(pageSize).ToList())
                    {
                        table.AddRow($"{item.ID_Transaction}", $"{item.Bank_Account.Number_Bank}", $"{item.Bank_Account.User.FullName}", $"{item.Bank_Account.User.CMND_CCCD}", $"{item.Bank_Account.Balance} VNĐ", $"{item.Bank_Account.User.Email}", $"{item.Bank_Account.User.Phone}", $"{item.amount} VNĐ", $"{item.status_transaction}", $"{item.created_at_transaction}");
                    }
                }
                AnsiConsole.Write(table);
                Console.WriteLine($"{AbstractLanguage.page} {pageNumber}/{pageCount}");
            }
        }
        public string DateOfBirthToString(DateTime item)
        {
            return item.Date.ToString("dd/MM/yyyy");
        }
    }
}
