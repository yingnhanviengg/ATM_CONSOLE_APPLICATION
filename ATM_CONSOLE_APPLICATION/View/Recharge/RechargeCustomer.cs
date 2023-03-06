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
            double amount = InputisValid.InputAmount();
            if (controllerRecharge.RequireReachaerge(amount))
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.SendRequire_Racharge_Success, true);
            }
            else { Common.PrintMessage_Console(Language.AbstractLanguage.SendRequire_Racharge_Error, false); }
        }
    }
}
