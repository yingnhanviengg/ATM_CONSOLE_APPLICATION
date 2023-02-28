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
            body = $"Xin chào {((ModelTranferMoney)model).Bank_Sender.User.FullName}<br/>" +
                $"Chuyển số tiền {((ModelTranferMoney)model).amount} thành công đến số tài khoản {((ModelTranferMoney)model).Bank_Recipient.Number_Bank}<br/>" +
                $"Sô dư hiện tại: {((ModelTranferMoney)model).Bank_Sender.Balance}<br/>" +
                $"Thời gian giao dịch {currentTime}";
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
