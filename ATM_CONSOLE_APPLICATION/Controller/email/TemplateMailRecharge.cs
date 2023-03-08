using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailRecharge : Email
    {
        public TemplateMailRecharge() { }
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
            return Mail(((ModelTransaction)model).Bank_Account.User.Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            DateTime currentTime = DateTime.Now;
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Xác nhận nạp tiền thành công";
            body = $"<!DOCTYPE html>" +
                   $"<html>" +
                   $"<head>" +
                   $"<meta charset='UTF-8'>" +
                   $"<title>Xác nhận yêu cầu nạp tiền</title>" +
                   $"</head>" +
                   $"<p>Xin chào {((ModelTransaction)model).Bank_Account.User.FullName}</p>" +
                   $"<p>Yêu cầu nạp tiền đã được quản trị viên xác nhận.</p>" +
                   $"<p>Thông báo thông tin tài khoản:</p>" +
                   $"<ul>" +
                   $"<li>Số tài khoản: {((ModelTransaction)model).Bank_Account.Number_Bank}</li>" +
                   $"<li>Số tiền nạp: {((ModelTransaction)model).amount}</li>" +
                   $"<li>Số dư hiện tại: {((ModelTransaction)model).Bank_Account.Balance}</li>" +
                   $"<li>Thời gian xác nhận yêu cầu: {currentTime}</li>" +
                   $"</ul>" +
                   $"<p>Xin cảm ơn đã sử dụng dịch vụ của chúng tôi.</p>" +
                   $"</html>";
        }
        public override void Mail_English(object model)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Xác nhận nạp tiền thành công";
            body = $"Xin chào {((ModelTransaction)model).Bank_Account.User.FullName}<br/>" +
                $"Yêu cầu nạp tiền đã được quản trị viên xác nhận <br/>" +
                $"Thông báo thông tin tài khoản:<br/>" +
                $"Số tài khoản: {((ModelTransaction)model).Bank_Account.Number_Bank}" +
                $"Số dư: {((ModelTransaction)model).Bank_Account.Balance}";
        }
    }
}
