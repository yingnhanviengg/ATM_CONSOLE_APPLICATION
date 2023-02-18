using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TempMailRegister_Success : Email
    {
        public override bool Mail(ModelBank_Account modelBank_Account)
        {
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
            subject = "Đăng ký tài khoản thành công";
            body = $"Xin chào {modelBank_Account.FullName}<br/>" +
                $"Cảm ơn bạn đã tạo tài khoản ATM CONSOLE APPLICATION<br/>" +
                $"Email này chứa toàn bộ thông tin quan trọng của bạn<br/>" +
                $"Tài khỏa đăng nhập: {modelBank_Account.Username}<br/>" +
                $"Mật khẩu: {modelBank_Account.Password}<br/>" +
                $"Số tài khoản ngân hàng: {modelBank_Account.Number_Bank}.";
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
