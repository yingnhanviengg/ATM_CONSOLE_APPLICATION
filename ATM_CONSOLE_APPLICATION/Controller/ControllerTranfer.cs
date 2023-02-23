using ATM_CONSOLE_APPLICATION.Controller.email;
using ATM_CONSOLE_APPLICATION.Model;
using ATM_CONSOLE_APPLICATION.View;

namespace ATM_CONSOLE_APPLICATION.Controller
{
    public class ControllerTranfer
    {
        public ControllerTranfer() { TranferMoney.GetListTranfer(); }
        public static List<ModelTranferMoney> List_TranferMoney
        {
            get { return ModelTranferMoney.List_TranferMoney; }
        }
        public static ModelTranferMoney TranferMoney
        {
            get { return ModelTranferMoney.TranferMoney; }
        }
        private static ControllerTranfer _controllerTranfer;
        public static ControllerTranfer _ControllerTranfer
        {
            get
            {
                if (_controllerTranfer == null)
                {
                    _controllerTranfer = new ControllerTranfer();
                }
                return _controllerTranfer;
            }
        }
        public int Tranfer(double amount, int id_bank_sender, string numberbank_recipient)
        {
            var bank_sender = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.ID_Bank.Equals(id_bank_sender));
            var bank_recipient = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.Number_Bank.Equals(numberbank_recipient));
            if (bank_recipient != default)
            {
                var tranfer = new ModelTranferMoney(amount, bank_sender, bank_recipient);
                if (bank_recipient.User.status_user.Equals("normal"))
                {
                    Email email = new TemplateMailTranfer_Money();
                    email.Mail(tranfer);
                    int cout = 3;
                    do
                    {
                        if (Email.code == InputisValid.InputCode())
                        {
                            if (tranfer.Tranfer(tranfer))
                            {
                                bank_sender.Balance -= tranfer.amount;
                                bank_recipient.Balance += tranfer.amount;
                                ControllerBank_User.UserBank.Balance -= tranfer.amount;
                                return 1;
                            }
                        }
                        else
                        {
                            cout--;
                            Common.PrintMessage_Console(Language.AbstractLanguage.Error_Code, false);
                            Common.PrintMessage_Console(Language.AbstractLanguage.Error_Code_Limit_3 + cout.ToString(), false);
                        }
                    } while (cout != 0);
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
            return 0;
        }
    }
}
