using ATM_CONSOLE_APPLICATION.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.View.Login_Register
{
    public interface ILogin_Register
    {
        public bool Login();
        public void Register();
    }
}
