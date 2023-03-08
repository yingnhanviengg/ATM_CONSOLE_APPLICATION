using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TempMailRegister_Success : Email
    {
        public override bool SendMail(object model)
        {
            if (Language.AbstractLanguage.Current_Language.Equals("Vietnamese"))
            {
                Mail_Vietnamese(model);
            }
            else if (Language.AbstractLanguage.Current_Language.Equals("English"))
            {
                Mail_English(model);
            }
            return Mail(((ModelBank_Account)model).User.Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Đăng ký tài khoản thành công";
            body = $@"<!DOCTYPE html>
    <html>
      <head>
        <meta charset='UTF-8'>
        <title>Thông tin tài khoản</title>
      </head>
      <body>
        <p>Xin chào {((ModelBank_Account)model).User.FullName},</p>
        <p>Cảm ơn bạn đã tạo tài khoản ATM CONSOLE APPLICATION</p>
        <p>Dưới đây là thông tin chi tiết về tài khoản của bạn:</p>
        <ul>
          <li>Tài khoản đăng nhập: {((ModelBank_Account)model).User.Username}</li>
          <li>Mật khẩu: {((ModelBank_Account)model).User.Password}</li>
          <li>Số tài khoản: {((ModelBank_Account)model).Number_Bank}</li>
          <p>Xin hãy lưu giữ thông tin này một cách an toàn để đảm bảo an ninh tài khoản của bạn.</p>
		<p>Xin cảm ơn đã sử dụng dịch vụ của chúng tôi.</p>
        </ul>
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
