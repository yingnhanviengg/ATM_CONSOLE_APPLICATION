using ATM_CONSOLE_APPLICATION.Controller;

namespace ATM_CONSOLE_APPLICATION.View.TranferMoney
{
    public class TranferCustomer
    {
        private static TranferCustomer? _tranferCustomer;
        public static TranferCustomer _TranferCustomer
        {
            get
            {
                if (_tranferCustomer == null)
                {
                    _tranferCustomer = new TranferCustomer();
                }
                return _tranferCustomer;
            }
        }
        private ControllerTranfer controllerTranfer = ControllerTranfer._ControllerTranfer;
        public void Tranfer()
        {
            string numberbank_recipient = InputisValid.InputNumberBank_Recipient();
            double deposits = InputisValid.InputAmount();
            switch (controllerTranfer.Tranfer(deposits, ControllerBank_User.UserBank.ID_Bank, numberbank_recipient))
            {
                case -1:
                    Common.PrintMessage_Console(Language.AbstractLanguage.NumberBank_NotExist, false);
                    break;
                case -2:
                    Common.PrintMessage_Console(Language.AbstractLanguage.NumberBank_Lock, false);
                    break;
                case 1:
                    Common.PrintMessage_Console(Language.AbstractLanguage.Tranfer_Success, true);
                    break;
                default:
                    Common.PrintMessage_Console(Language.AbstractLanguage.Tranfer_Error, false);
                    break;
            }
        }
    }
}
