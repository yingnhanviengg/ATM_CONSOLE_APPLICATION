using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailTranferToRecipient : Email
    {
        public TemplateMailTranferToRecipient() { }
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
            return Mail(((ModelTranferMoney)model).Bank_Recipient.User.Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            DateTime currentTime = DateTime.Now;
            SendMail_Success = null;
            SendMail_Error = null;
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
          <li>Sô dư hiện tại: {((ModelTranferMoney)model).Bank_Recipient.Balance}</li>
        </ul>
        <p>Xin cảm ơn và chúc bạn một ngày tốt lành!</p>
      </body>
    </html>";
        }
        public override void Mail_English(object model)
        {
            DateTime currentTime = DateTime.Now;
            SendMail_Success = null;
            SendMail_Error = null;
            subject = "Account Balance Notification";
            body = $@"<!DOCTYPE html>
    <html>
      <head>
        <meta charset='UTF-8'>
        <title>Account Balance Notification</title>
      </head>
      <body>
        <p>Hello {((ModelTranferMoney)model).Bank_Recipient.User.FullName},</p>
        <p>Your transfer request has been completed </p>
        <p>Transaction details:</p>
        <ul>
          <li>Sender's account number: {((ModelTranferMoney)model).Bank_Sender.Number_Bank}</li>
          <li>Sender's name: {((ModelTranferMoney)model).Bank_Sender.User.FullName}</li>
          <li>Transfer amount: {((ModelTranferMoney)model).amount}</li>
          <li>Recipient's account number: {((ModelTranferMoney)model).Bank_Recipient.Number_Bank}</li>
          <li>Recipient's name: {((ModelTranferMoney)model).Bank_Recipient.User.FullName}</li>
          <li>Current balance: {((ModelTranferMoney)model).Bank_Recipient.Balance}</li>
        </ul>
        <p>Thank you and have a nice day!</p>
      </body>
    </html>";
        }

    }
}
