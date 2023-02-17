using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Email() {    }
        public abstract bool Mail();
        public abstract void Mail_Vietnamese();
        public abstract void Mail_English();
        public bool SendMail(string to)
        {
            bool success = false;
            // Tạo message email
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ATM CONSOLE APPLICATION", from));
            message.To.Add(new MailboxAddress("Customer", to));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };
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
