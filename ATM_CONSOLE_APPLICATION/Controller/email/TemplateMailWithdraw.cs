using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailWithdraw : Email
    {
        public TemplateMailWithdraw()
        {

        }
        public override bool Mail()
        {
            if (Language.Current_Language.Equals("Vietnamese"))
            {
                Mail_Vietnamese();
            }
            else if (Language.Current_Language.Equals("English"))
            {
                Mail_English();
            }
            if (SendMail(Language.Current_Language))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Mail_Vietnamese()
        {
            subject = "Mã xác nhận rút tiền";
            body = "Đây là mã xác minh rút tiền của bạn ";
        }
        public override void Mail_English()
        {
            subject = "Withdrawal confirmation code";
            body = "This is your withdrawal confirmation code";
        }
    }
}
