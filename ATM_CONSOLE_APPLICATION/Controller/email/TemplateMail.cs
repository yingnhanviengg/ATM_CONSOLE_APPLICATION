using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMail
    {
        public static string Hello_Mail { get; set; }
        public static string SendMail_Success { get; set; }
        public static string SendMail_Error { get; set; }
        public static string Subject_Mail { get; set; }
        public static string Body_Mail { get; set; }
        public TemplateMail()
        {

        }
        
    }
}
