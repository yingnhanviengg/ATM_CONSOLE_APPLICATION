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
        public void Mail_Register_Vietnamese()
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra email của bạn";
            Subject_Mail = "Mã xác nhận đăng ký tài khoản";
            Hello_Mail = "Xin chào ";
            Body_Mail = " đây là mã xác minh đăng ký tài khoản của bạn ";
        }
        public static void Mail_Register_English()
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra email của bạn";
            Subject_Mail = "Mã xác nhận đăng ký tài khoản";
            Hello_Mail = "Xin chào ";
            Body_Mail = " đây là mã xác minh đăng ký tài khoản của bạn ";
        }
        
    }
}
