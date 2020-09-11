using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.Common.Helpers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Services
{
    /// <summary>
    /// Сервис отвечающий за отправку E-mail 
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IOptions<EmailSettings> _options;

        public EmailService(IOptions<EmailSettings> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", _options.Value.Email));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_options.Value.Host, _options.Value.Port, _options.Value.Ssl);
            await client.AuthenticateAsync(_options.Value.Email, _options.Value.Password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(_options.Value.Disconnect);
        }
    }
}
