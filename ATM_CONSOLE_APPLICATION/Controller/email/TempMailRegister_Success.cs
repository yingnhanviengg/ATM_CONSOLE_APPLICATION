using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TempMailRegister_Success : Email
    {
        public override bool Mail(object model)
        {
            if (Language.AbstractLanguage.Current_Language.Equals("Vietnamese"))
            {
                Mail_Vietnamese(model);
            }
            else if (Language.AbstractLanguage.Current_Language.Equals("English"))
            {
                Mail_English(model);
            }
            return SendMail(((ModelBank_Account)model).User.Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Đăng ký tài khoản thành công";
            body = $"Xin chào {((ModelBank_Account)model).User.FullName}<br/>" +
                $"Cảm ơn bạn đã tạo tài khoản ATM CONSOLE APPLICATION<br/>" +
                $"Email này chứa toàn bộ thông tin quan trọng của bạn<br/>" +
                $"Tài khỏa đăng nhập: {((ModelBank_Account)model).User.Username}<br/>" +
                $"Mật khẩu: {((ModelBank_Account)model).User.Password}<br/>" +
                $"Số tài khoản ngân hàng: {((ModelBank_Account)model).Number_Bank}";
        }
        public override void Mail_English(object model)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Account registration confirmation code";
            body = "This is your account registration verification code";
        }
    }
}
