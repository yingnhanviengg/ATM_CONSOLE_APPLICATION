using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.View.Login_Register;
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
        Login_Register.Login_Register login_Register = Login_Register.Login_Register._Login_Register;
        private static AbstractMenu? _menu = null;
        public static AbstractMenu Menu
        {
            get
            {
                if (ControllerBank_User.UserBank.User.role.Equals("customer"))
                {
                    _menu = MenuCustomer._MenuCustomer;
                }
                if (ControllerBank_User.UserBank.User.role.Equals("admin"))
                {
                    _menu = MenuAdmin._MenuAdmin;
                }
                return _menu;
            }
        }
        private static MainMenu _mainMenu;
        public static MainMenu _MainMenu
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new MainMenu();
                }
                return _mainMenu;
            }
        }
        public ControllderUser ControllerUser = ControllderUser.__ControllerUser;
        public void ShowMainMenu()
        {
            ChangeLanguage.Change_Language();
            Login();
        }
        public void Login()
        {
            Console.Clear();
            if (login_Register.MenuLogin())
            {
                Menu.ShowMenu();
            }
        }
    }
}
