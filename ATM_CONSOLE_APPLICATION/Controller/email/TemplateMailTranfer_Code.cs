using ATM_CONSOLE_APPLICATION.Model;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailTranfer_Code : Email
    {
        public TemplateMailTranfer_Code() { }
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
            return Mail(((ModelTranferMoney)model).Bank_Sender.User.Email);
        }
        public override void Mail_Vietnamese(object model)
        {
            SendMail_Success = "Gửi email thành công hẫy kiểm tra tài khoản gmail của bạn";
            SendMail_Error = "Gửi email thất bại hẫy kiểm tra lại nhập lại gmail";
            subject = "Mã xác nhận chuyển tiền";
            body = $@"<!DOCTYPE html>
    <html>
      <head>
        <meta charset='UTF-8'>
        <title>Xác nhận giao dịch chuyển khoản</title>
      </head>
      <body>
        <p>Xin chào {((ModelTranferMoney)model).Bank_Sender.User.FullName},</p>
        <p>Yêu cầu giao dịch chuyển tiền </p>
        <p>Thông tin chi tiết giao dịch như sau:</p>
        <ul>
          <li>Số tài khoản gửi: {((ModelTranferMoney)model).Bank_Sender.Number_Bank}</li>
          <li>Tên người gửi: {((ModelTranferMoney)model).Bank_Sender.User.FullName}</li>
          <li>Số tiền chuyển: {((ModelTranferMoney)model).amount}</li>
          <li>Số tài khoản nhận: {((ModelTranferMoney)model).Bank_Recipient.Number_Bank}</li>
          <li>Tên người nhận: {((ModelTranferMoney)model).Bank_Recipient.User.FullName}</li>
          <li>Mã xác minh giao dịch: {code}</li>
        <p>Vui lòng sử dụng mã xác minh này để hoàn tất yêu cầu giao dịch.</p>
        </ul>
        <p>Xin cảm ơn và chúc bạn một ngày tốt lành!</p>
      </body>
    </html>";
        }
        public override void Mail_English(object model)
        {
            SendMail_Success = "Email sent successfully, please check your gmail account";
            SendMail_Error = "Failed to send email, please check and re-enter your gmail";
            subject = "Transfer confirmation code";
            body = $@"<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<title>Transaction confirmation for money transfer</title>
</head>
<body>
<p>Hello {((ModelTranferMoney)model).Bank_Sender.User.FullName},</p>
<p>Money transfer request</p>
<p>Transaction details are as follows:</p>
<ul>
<li>Sending account number: {((ModelTranferMoney)model).Bank_Sender.Number_Bank}</li>
<li>Sender name: {((ModelTranferMoney)model).Bank_Sender.User.FullName}</li>
<li>Transfer amount: {((ModelTranferMoney)model).amount}</li>
<li>Recipient account number: {((ModelTranferMoney)model).Bank_Recipient.Number_Bank}</li>
<li>Recipient name: {((ModelTranferMoney)model).Bank_Recipient.User.FullName}</li>
<li>Transaction verification code: {code}</li>
</ul>
<p>Please use this verification code to complete the transaction request.</p>
<p>Thank you and have a nice day!</p>
</body>
</html>";
        }
    }
}
