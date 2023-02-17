using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailRegister : TemplateMail
    {
        public TemplateMailRegister()
        {

        }
        public override void Mail_Vietnamese()
        {
            base.Mail_Vietnamese();
            Subject_Mail = "Mã xác nhận đăng ký tài khoản";
            Body_Mail = "Đây là mã xác minh đăng ký tài khoản của bạn ";
        }
        public override void Mail_English()
        {
            base.Mail_English();
            Subject_Mail = "Mã xác nhận đăng ký tài khoản123";
            Body_Mail = " đây là mã xác minh đăng ký tài khoản của bạn123 ";
        }       
    }
}
