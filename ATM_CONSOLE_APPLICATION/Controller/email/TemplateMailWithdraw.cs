namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailWithdraw : Email
    {
        public TemplateMailWithdraw()
        {

        }
        public override bool Mail(object model)
        {
            if (Language.AbstractLanguage.Current_Language.Equals("Vietnamese"))
            {
                Mail_Vietnamese(model);
            }
            else if (Language.AbstractLanguage.Current_Language.Equals("English"))
            {
                Mail_English(model);
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
        public override void Mail_Vietnamese(object model)
        {
            subject = "Mã xác nhận rút tiền";
            body = "Đây là mã xác minh rút tiền của bạn ";
        }
        public override void Mail_English(object model)
        {
            subject = "Withdrawal confirmation code";
            body = "This is your withdrawal confirmation code";
        }
    }
}
