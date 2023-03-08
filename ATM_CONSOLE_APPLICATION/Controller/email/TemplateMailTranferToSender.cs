using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailTranferToSender : Email
    {
        public TemplateMailTranferToSender() { }
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
            return Mail(((ModelTranferMoney)model).Bank_Sender.User.Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            DateTime currentTime = DateTime.Now;
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Thông Báo Số Dư Tài Khoản";
            body = $@"<!DOCTYPE html>
    <html>
      <head>
        <meta charset='UTF-8'>
        <title>Thông báo số dư tài </title>
      </head>
      <body>
        <p>Xin chào {((ModelTranferMoney)model).Bank_Recipient.User.FullName},</p>
        <p>Hoàn tất yêu cầu chuyển </p>
        <p>Thông tin chi tiết giao dịch như sau:</p>
        <ul>
          <li>Số tài khoản gửi: {((ModelTranferMoney)model).Bank_Sender.Number_Bank}</li>
          <li>Tên người gửi: {((ModelTranferMoney)model).Bank_Sender.User.FullName}</li>
          <li>Số tiền chuyển: {((ModelTranferMoney)model).amount}</li>
          <li>Số tài khoản nhận: {((ModelTranferMoney)model).Bank_Recipient.Number_Bank}</li>
          <li>Tên người nhận: {((ModelTranferMoney)model).Bank_Recipient.User.FullName}</li>
          <li>Sô dư hiện tại: {((ModelTranferMoney)model).Bank_Sender.Balance}</li>
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
