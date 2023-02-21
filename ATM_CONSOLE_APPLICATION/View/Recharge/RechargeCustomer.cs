using ATM_CONSOLE_APPLICATION.View.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_CONSOLE_APPLICATION.Controller;
using Org.BouncyCastle.Math.Field;

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
        ControllerTransaction controllerRecharge = ControllerTransaction._ControllerRecharge;
        public void Recharge()
        {
            Console.WriteLine(Language.AbstractLanguage.Input_Amount);
            double amount = Convert.ToDouble(Console.ReadLine());
            var rechager = new Model.ModelTransaction(ControllerBank_User.UserBank, type: string.Empty, amount, status_transaction: string.Empty);
            if (controllerRecharge.RequireReachaerge(rechager))
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.SendRequire_Racharge_Success, true);
            }
            else
            {
                Common.PrintMessage_Console(Language.AbstractLanguage.SendRequire_Racharge_Error, false);
            }
        }
    }
}
