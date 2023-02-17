using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailTranfer_Money : TemplateMail
    {
        public TemplateMailTranfer_Money()
        {

        }
        public override void Mail_Vietnamese()
        {
            base.Mail_Vietnamese();
            Subject_Mail = "Mã xác nhận chuyển tiền";
            Body_Mail = "Đây là mã xác minh chuyển tiền của bạn ";
        }
        public override void Mail_English()
        {
            base.Mail_English();
            Subject_Mail = "Transfer confirmation code";
            Body_Mail = "This is your transfer confirmation code";
        }
    }
}
