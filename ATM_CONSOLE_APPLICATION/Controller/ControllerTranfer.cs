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

    }
}
