using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            body = $"Xin chào {((ModelTranferMoney)model).Bank_Recipient.User.FullName}<br/>" +
                $"Nhận được số tiền {((ModelTranferMoney)model).amount} từ số tài khoản {((ModelTranferMoney)model).Bank_Sender.Number_Bank}<br/>" +
                $"Sô dư hiện tại: {((ModelTranferMoney)model).Bank_Recipient.Balance}<br/>" +
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
