using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MagicEnglish.Utils
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("lmx295483895@163.com", "MagicEnglish");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void SendWithAttachment(String toEmail, String subject, String contents, string path, string filename)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("lmx295483895@163.com", "MagicEnglish");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var attach = File.ReadAllBytes(path);
            msg.AddAttachment(filename, Convert.ToBase64String(attach));
            var response = client.SendEmailAsync(msg);
        }
    }
}