using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller
{
    public class ControllerRecharge
    {
        public ControllerRecharge()
        {

        }
        private static ControllerRecharge _controllerRecharge;
        public static ControllerRecharge _ControllerRecharge
        {
            get
            {
                if (_controllerRecharge == null)
                {
                    _controllerRecharge = new ControllerRecharge();
                }
                return _controllerRecharge;
            }
        }
        public bool IsRechaerge(ModelBank_Account user)
        {
            var index = ControllerBank_User.ListBank_User.FindIndex(x => x.ID_User.Equals(user.ID_User));
            if (index != -1)
            {
                var valid = ControllerBank_User.ListBank_User[index];
                ControllerBank_User.ListBank_User[index].Balance = user.Balance;
            }              
            ControllerBank_User.UserBank.Balance = user.Balance;
            return true;
        }
        public bool RequireReachaerge(ModelTransaction user)
        {
            user.Type_Tracsaction = "recharge";
            user.status_transaction = "processing";
            if (user.Hitory_Rechager(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
