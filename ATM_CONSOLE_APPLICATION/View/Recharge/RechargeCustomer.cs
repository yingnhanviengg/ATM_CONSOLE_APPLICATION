using ATM_CONSOLE_APPLICATION.Controller;

namespace ATM_CONSOLE_APPLICATION.View.Recharge
{
    public class RechargeCustomer
    {
        private static RechargeCustomer? _rechargeCustomer;
        public static RechargeCustomer _RechargeCustomer
        {
            get
            {
                if (_rechargeCustomer == null)
                {
                    _rechargeCustomer = new RechargeCustomer();
                }
                return _rechargeCustomer;
            }
        }
        ControllerTransaction controllerRecharge = ControllerTransaction._ControllerTransaction;
        public void Recharge()
        {
            Console.Write(Language.AbstractLanguage.Input_Amount);
            double amount = Convert.ToDouble(Console.ReadLine());
            if (controllerRecharge.RequireReachaerge(amount))
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.SendRequire_Racharge_Success, true);
            }
            else { Common.PrintMessage_Console(Language.AbstractLanguage.SendRequire_Racharge_Error, false); }
        }
    }
}
