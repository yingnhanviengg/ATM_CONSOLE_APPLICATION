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
        public string InputCMND_CCCD();
        public string InputGender();
        public string InputFullName();
        public string InputPassword();
        public string InptUsername();
        public string InputAddress();
        public string GetPhoneNumber();
        public string GetValidEmail();
        public bool IsValidEmail(string email);
        public DateTime InputDateTime();
        public string StandardizeString(string str);
        public bool IsValidUsername(string str);
        public string GetPassword();
    }
}
