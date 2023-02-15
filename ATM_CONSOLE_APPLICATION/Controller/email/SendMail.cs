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
            string from = "yingnhanviengg@gmail.com";
            string to = "nguyenducphonghai@gmail.com";
            string subject = "Email verification code";
            string body = $"Your verification code is {code}.";

            try
            {
                UserCredential credential;

                using (var stream = new FileStream("C:\\Users\\Ying\\source\\repos\\ATM_CONSOLE_APPLICATION\\ATM_CONSOLE_APPLICATION\\Controller\\email\\client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "C:\\Users\\Ying\\source\\repos\\ATM_CONSOLE_APPLICATION\\ATM_CONSOLE_APPLICATION\\Controller\\email\\token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { GmailService.Scope.GmailSend },
                        "user",
                        System.Threading.CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "ATM Console Application"
                });

                Message message = new Message();
                message.Raw = Base64UrlEncode(CreateEmailMessage(from, to, subject, body).ToString());

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
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes).Replace('+', '-').Replace('/', '_').Replace("=", "");
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
