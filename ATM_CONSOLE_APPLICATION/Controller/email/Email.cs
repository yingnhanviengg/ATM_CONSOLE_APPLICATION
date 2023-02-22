using ATM_CONSOLE_APPLICATION.Model;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Org.BouncyCastle.Asn1.Ocsp;

namespace ATM_CONSOLE_APPLICATION.Controller.email
{
    public abstract class Email
    {
        private static string from = "yingnhanviengg@gmail.com";
        private static string password = "keguitumpfxrvpus";
        public string? SendMail_Success { get; set; }
        public string? SendMail_Error { get; set; }
        public string? subject { get; set; }
        public string? body { get; set; }
        public static string code { get; set; }
        public static string signature { get; set; }
        public Email() {    }
        public abstract bool Mail(object model);
        //update
        public abstract void Mail_Vietnamese(object model);
        public abstract void Mail_English(object model);
        public bool SendMail(string to)
        {
            bool success = false;
            // Tạo message email
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ATM CONSOLE APPLICATION", from));
            message.To.Add(new MailboxAddress("Customer", to));
            message.Subject = subject;
            signature = "<p style='font-size: 10px; color: gray;'>ATM CONSOLE APPLICATION<br/>" +
            "Coded with love by Ying and VuAnh, This code is the product of countless cups of coffee<br/>" +
            "Email: yingnhanviengg@gmail.com or anhvt290791@gmail.com<br/>" +
            "Phone: 0345211459</p>" +
            "<hr style='border-top: 3px solid #ccc; margin: 10px 0;'>";

            message.Body = new TextPart("html") { Text = body + signature };
            try
            {
                // Tạo kết nối SMTP
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    // Xác thực tài khoản email gửi
                    client.Authenticate(from, password);

                    // Gửi email
                    client.Send(message);

                    client.Disconnect(true);
                }
                Common.PrintMessage_Console(SendMail_Success, true);
                success = true;
            }
            catch (Exception ex)
            {
                Common.PrintMessage_Console(SendMail_Error + ex.Message, false);
                success = false;
            }
            return success;
        }
        public static string GenerateRandomCode()
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
