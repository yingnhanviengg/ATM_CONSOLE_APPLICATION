﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public class TemplateMailTranfer_Money : TemplateMail
    {
        public TemplateMailTranfer_Money()
        {

        }
        public override void Mail_Vietnamese()
        {
            base.Mail_Vietnamese();
            Subject_Mail = "Mã xác nhận rút tiền";
            Body_Mail = " đây là mã xác minh rút tiền của bạn ";
        }
        public override void Mail_English()
        {
            base.Mail_English();
            Subject_Mail = "Mã xác nhận đăng ký tài khoản123";
            Body_Mail = " đây là mã xác minh đăng ký tài khoản của bạn123 ";
        }
    }
}