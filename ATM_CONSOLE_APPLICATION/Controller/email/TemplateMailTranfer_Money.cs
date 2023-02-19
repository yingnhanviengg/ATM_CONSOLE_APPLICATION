using ATM_CONSOLE_APPLICATION.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailTranfer_Money : Email
    {
        public TemplateMailTranfer_Money()
        {

        }
        public override bool Mail(ModelBank_Account modelBank_Account)
        {

            if (Language.AbstractLanguage.Current_Language.Equals("Vietnamese"))
            {
                Mail_Vietnamese(modelBank_Account);
            }
            else if (Language.AbstractLanguage.Current_Language.Equals("English"))
            {
                Mail_English(modelBank_Account);
            }
            if (SendMail(Language.AbstractLanguage.Current_Language))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Mail_Vietnamese(ModelBank_Account modelBank_Account)
        {
            subject = "Mã xác nhận chuyển tiền";
            body = "Đây là mã xác minh chuyển tiền của bạn ";
        }
        public override void Mail_English(ModelBank_Account modelBank_Account)
        {
            subject = "Transfer confirmation code";
            body = "This is your transfer confirmation code";
        }
    }
}
