using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailRegister_Code : Email
    {
        public TemplateMailRegister_Code()
        {

        }
        public override bool Mail(ModelBank_Account modelBank_Account)
        {
            code = GenerateRandomCode();
            if (Language.Current_Language.Equals("Vietnamese"))
            {
                Mail_Vietnamese(modelBank_Account);
            }
            else if (Language.Current_Language.Equals("English"))
            {
                Mail_English(modelBank_Account);
            }         
            if (SendMail(modelBank_Account.Email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Mail_Vietnamese(ModelBank_Account modelBank_Account)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Mã xác nhận đăng ký tài khoản";
            body = $"Xin chào {modelBank_Account.FullName}\n" +
                $"Đây là mã xác minh đăng ký tài khoản {modelBank_Account.Username} của bạn {code}" +
                $"{signature}";
        }
        public override void Mail_English(ModelBank_Account modelBank_Account)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Account registration confirmation code";
            body = "This is your account registration verification code";
        }       
    }
}
