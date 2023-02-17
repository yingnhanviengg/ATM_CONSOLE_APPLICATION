using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailWithdraw : TemplateMail
    {
        public TemplateMailWithdraw()
        {

        }
        public override void Mail_Vietnamese()
        {
            base.Mail_Vietnamese();
            Subject_Mail = "Mã xác nhận rút tiền";
            Body_Mail = "Đây là mã xác minh rút tiền của bạn ";
        }
        public override void Mail_English()
        {
            base.Mail_English();
            Subject_Mail = "Withdrawal confirmation code";
            Body_Mail = "This is your withdrawal confirmation code";
        }
    }
}
