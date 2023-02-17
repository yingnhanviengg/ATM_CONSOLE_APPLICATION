using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMail
    {
        public static string? Hello_Mail { get; set; }
        public static string? SendMail_Success { get; set; }
        public static string? SendMail_Error { get; set; }
        public static string? Subject_Mail { get; set; }
        public static string? Body_Mail { get; set; }
        public TemplateMail()
        {

        }
        public virtual void Mail_Vietnamese()
        {
            Hello_Mail = "Xin chào ";
            SendMail_Success = "Gửi email thành công hãy kiểm tra gmail của bạn";
            SendMail_Error = "Gửi mail không thành công";
        }
        public virtual void Mail_English()
        {
            Hello_Mail = "Hello ";
            SendMail_Success = "Email sent successfully. Please check your gmail!";
            SendMail_Error = "Email sent failed. Please check again!";
        }
    }
}
