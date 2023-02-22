using ATM_CONSOLE_APPLICATION.Controller;
using ATM_CONSOLE_APPLICATION.Language;
using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.TranferMoney
{
    public class TranferCustomer
    {
        private ControllerTranfer controllerTranfer = ControllerTranfer._ControllerTranfer;
        public void Tranfer()
        {
            string numberbank_recipient = InputisValid.InputNumberBank_Recipient();
            double deposits = InputisValid.InputDeposits();
            var tranfer = new ModelTranferMoney(deposits, new ModelBank_Account(ControllerBank_User.UserBank.ID_Bank), new ModelBank_Account(numberbank_recipient));

        }
    }
}
