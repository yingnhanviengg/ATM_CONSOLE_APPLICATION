using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailWithdraw : Email
    {
        public TemplateMailWithdraw() { }
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
            return Mail(((ModelTransaction)model).Bank_Account.User.Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            DateTime currentTime = DateTime.Now;
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Rút Tiền Thành Công";
            body = $@"<!DOCTYPE html>
    <html>
      <head>
        <meta charset='UTF-8'>
        <title>Thông báo số dư tài </title>
      </head>
      <body>
        <p>Xin chào {((ModelTranferMoney)model).Bank_Recipient.User.FullName},</p>
        <p>Xác nhận yêu cầu rút tiền của bạn đã được xử lý thành công vào lúc {currentTime} </p>
        <p>Thông tin chi tiết giao dịch như sau:</p>
        <ul>
            <li>Số tiền đã rút: {((ModelTransaction)model).amount}</li>
            <li>Số dư hiện tại: {((ModelTransaction)model).Bank_Account.Balance}</li>
        </ul>
        <p>Xin cảm ơn và chúc bạn một ngày tốt lành!</p>
      </body>
    </html>"; 
        }
        public override void Mail_English(object model)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Transfer confirmation code";
            body = "This is your transfer confirmation code";
        }
    }
}
