using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace ATM_CONSOLE_APPLICATION
{
    public static class SendMail
    {
        public static void SendMailCode(string code)
        {
            // Địa chỉ email người gửi
            string from = "yingnhanviengg@gmail.com";
            // Địa chỉ email người nhận
            string to = "nguyenducphonghai@gmail.com";
            // Tiêu đề email
            string subject = "Email verification code";
            // Nội dung email
            string body = $"Your verification code is {code}.";
            try
            {
                /// Xác thực người dùng
                UserCredential credential;

                // Tạo đối tượng client secrets từ chuỗi JSON
                ClientSecrets secrets = new ClientSecrets()
                {
                    ClientId = "1023815594177-g2cceo7j46je92k6k2qdn8vs45a0l0me.apps.googleusercontent.com",
                    ClientSecret = "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",
                };

                // Sử dụng đối tượng client secrets để xác thực
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    secrets,
                    new[] { GmailService.Scope.GmailSend },
                    "user",
                    System.Threading.CancellationToken.None,
                    new FileDataStore("CredentialCache")).Result;

                // Khởi tạo service Gmail
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "ATM Console Application"
                });

                // Khởi tạo service Gmail
                Message message = new Message();
                message.Raw = Base64UrlEncode(CreateEmailMessage(from, to, subject, body).ToString());
                // Gửi email
                var result = service.Users.Messages.Send(message, "me").Execute();
                Console.WriteLine("Message sent: " + result.LabelIds[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
        }

        private static StringBuilder CreateEmailMessage(string from, string to, string subject, string body)
        {
            // Tạo email message
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("From: <" + from + ">");
            sb.AppendLine("To: <" + to + ">");
            sb.AppendLine("Subject: " + subject);
            sb.AppendLine("MIME-Version: 1.0");
            sb.AppendLine("Content-Type: text/html; charset=UTF-8");
            sb.AppendLine("Content-Transfer-Encoding: 7bit");
            sb.AppendLine();
            sb.AppendLine(body);
            return sb;
        }

        private static string Base64UrlEncode(string input)
        {
            // Encode message sang Base64Url
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes).Replace('+', '-').Replace('/', '_').Replace("=", "");
        }
        public static string GenerateRandomCode()
        {
            // Encode message sang Base64Url
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
