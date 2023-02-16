using System;
using System.Net.Mail;
using ATM_CONSOLE_APPLICATION.Controller.email;
using MailKit.Net.Smtp;
using MimeKit;
using Spectre.Console;

namespace ATM_CONSOLE_APPLICATION
{
    public class Email
    {
        // Tài khoản email gửi
        private static string from = "yingnhanviengg@gmail.com";
        private static string password = "keguitumpfxrvpus";
        private static string? subject;
        private static string? body;
        public static string? code { get; set; }
        public static void MailWithdraw(string fullname)
        {
            TemplateMailWithdraw template = new TemplateMailWithdraw();
            // Tiêu đề email
            if (Language.Current_Language.Equals("Vietnamese"))
            {
                template.Mail_Vietnamese();
            }
            else if (Language.Current_Language.Equals("English"))
            {
                template.Mail_English();
            }
            subject = TemplateMail.Subject_Mail;
            // Nội dung email
            code = GenerateRandomCode();
            body = TemplateMail.Hello_Mail + fullname + TemplateMail.Body_Mail + "\" " + code + "\" ";
        }
        public static void MailRegister(string fullname)
        {
            TemplateMailRegister template = new TemplateMailRegister();
            // Tiêu đề email
            if (Language.Current_Language.Equals("Vietnamese"))
            {
                template.Mail_Vietnamese();
            }
            else if (Language.Current_Language.Equals("English"))
            {
                template.Mail_English();
            }
            subject = TemplateMail.Subject_Mail;
            // Nội dung email
            code = GenerateRandomCode();
            body = TemplateMail.Hello_Mail + fullname + TemplateMail.Body_Mail + "\" " + code + "\" ";
        }
        public static bool SendMail(string to)
        {               
            bool success = false;
            // Tạo message email
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("", from));
            message.To.Add(new MailboxAddress("", to));
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
                Console.WriteLine(TemplateMail.SendMail_Success);
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(TemplateMail.SendMail_Error + ex.Message);
                success = false;
            }
            return success;
        }
        public static bool Send_Mail_Register(string email, string fullname)
        {
            Email.MailRegister(fullname);
            if (Email.SendMail(email))
            {
                return true;
            }
            return false;
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
