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
            SendMail_Success = "Email sent successfully. Please check your Gmail account.";
            SendMail_Error = "Failed to send email. Please check your Gmail account and try again.";
            subject = "Account registration confirmation";
            body = $@"<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<title>Account Information</title>
</head>
<body>
<p>Hello {((ModelBank_Account)model).User.FullName},</p>
<p>Thank you for creating an account with ATM CONSOLE APPLICATION.</p>
<p>Below are the details of your account:</p>
<ul>
<li>Login ID: {((ModelBank_Account)model).User.Username}</li>
<li>Password: {((ModelBank_Account)model).User.Password}</li>
<li>Account Number: {((ModelBank_Account)model).Number_Bank}</li>
<p>Please keep this information safe to ensure the security of your account.</p>
<p>Thank you for using our service.</p>
</ul>
</body>
</html>";
        }
    }
}
