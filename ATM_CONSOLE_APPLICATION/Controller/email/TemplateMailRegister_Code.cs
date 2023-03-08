using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailRegister_Code : Email
    {
        public TemplateMailRegister_Code() { }
        public override bool SendMail(object model)
        {
            code = GenerateRandomCode();
            if (Language.AbstractLanguage.Current_Language.Equals("Vietnamese"))
            {
                Mail_Vietnamese(model);
            }
            else if (Language.AbstractLanguage.Current_Language.Equals("English"))
            {
                Mail_English(model);
            }
            return Mail(((ModelUser)model).Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Mã xác nhận đăng ký tài khoản";
            body = $@"<!DOCTYPE html>
    <html>
      <head>
        <meta charset='UTF-8'>
        <title>Xác nhận đăng ký tài khoản</title>
      </head>
      <body>
        <p>Xin chào {((ModelUser)model).FullName},</p>
        <p>Cảm ơn bạn đã đăng ký tài khoản {((ModelUser)model).Username}.</p>
        <p>Dưới đây là mã xác minh của bạn:</p>
        <p style='font-size: 24px; font-weight: bold; color: red;'>{code}</p>
        <p>Vui lòng sử dụng mã này để hoàn tất quá trình đăng ký tài khoản.</p>
        <p>Xin cảm ơn và chúc bạn một ngày tốt lành!</p>
      </body>
    </html>";
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
