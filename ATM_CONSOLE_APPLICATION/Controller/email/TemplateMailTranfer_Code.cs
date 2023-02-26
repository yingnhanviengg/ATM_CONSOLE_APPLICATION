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
            body = $"Xin chào {((ModelTranferMoney)model).Bank_Sender.User.FullName}<br/>" +
                $"Đây là mã xác minh {code} chuyển số tiền {((ModelTranferMoney)model).amount} đến số tài khoản {((ModelTranferMoney)model).Bank_Recipient.Number_Bank}.";
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
