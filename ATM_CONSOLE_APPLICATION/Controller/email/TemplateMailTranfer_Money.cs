using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailTranfer_Money : Email
    {
        public TemplateMailTranfer_Money()
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
            subject = "Mã xác nhận chuyển tiền";
            body = "Đây là mã xác minh chuyển tiền của bạn ";
        }
        public override void Mail_English()
        {
            subject = "Transfer confirmation code";
            body = "This is your transfer confirmation code";
        }
    }
}
