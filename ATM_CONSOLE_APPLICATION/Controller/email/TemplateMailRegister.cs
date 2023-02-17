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
            code = GenerateRandomCode();
            if (SendMail(ControllerBank_User._User.Email))
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
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Mã xác nhận đăng ký tài khoản";
            body = $"Xin chào {ControllerBank_User._User.FullName} \n" +
                $"Đây là mã xác minh đăng ký tài khoản {ControllerBank_User._User.Username} của bạn {code}";
        }
        public override void Mail_English()
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Account registration confirmation code";
            body = "This is your account registration verification code";
        }       
    }
}
