using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Tranfer_Money(ModelTranferMoney tranfer)
        {
            var bank_recipient = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.Number_Bank.Equals(tranfer.Bank_Recipient.Number_Bank));
            var bank_sender = ControllerBank_User.ListBank_User.FirstOrDefault(x => x.ID_Bank.Equals(tranfer.Bank_Sender.ID_Bank));
        }
    }
}
