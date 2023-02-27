using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Menu;
using ATM_CONSOLE_APPLICATION.View.Withdraw;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION.View
{
    public class MainMenu
    {
        public MainMenu()
        {
            ControllderUser controllderUser = ControllderUser.__ControllerUser;
            ControllerBank_User controllerBank_User = ControllerBank_User.ControllerUser;
            ControllerCard controllerCard = ControllerCard.controllerCard;
            ControllerTransaction controllerTransaction = ControllerTransaction._ControllerTransaction;
            ControllerTranfer controllerTranfer = ControllerTranfer._ControllerTranfer;
        }
        private static AbstractMenu? _menu = null;
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
            string[] Menu_Customer = { Language.AbstractLanguage.Login, Language.AbstractLanguage.Register, AbstractLanguage.Withdraw_Money_Customer };
            bool result = false;
            Login_Register.Login_Register login_Register = Login_Register.Login_Register._Login_Register;
            do
            {
                Common.UI();
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
                        result = login_Register.Login();
                        break;
                    case 1:
                        Console.Clear();
                        login_Register.Register();
                        break;
                    case 2:
                        Console.Clear();
                        VWithdraw vWithdraw = VWithdraw._Withdraw;
                        vWithdraw.Withdraw();
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
                Menu.ShowMenu();
            }
        }
    }
}
