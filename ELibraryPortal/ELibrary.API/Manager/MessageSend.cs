using ELibrary.API.Models;
using ELibrary.API.Models.Abstract;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using System.Text.RegularExpressions;

namespace ELibrary.API.Manager
{
    public class MessageSend : IEmailSend
    {
        public MessageSend(IOptions<MessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public MessageSenderOptions Options { get; set; }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = "YOUR SENDGRID API Key";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("support@dotnetthoughts.net", "Support");
            var to = new EmailAddress(email);
            var plainTextContent = Regex.Replace(message, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
