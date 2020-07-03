using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Services
{
    /// <summary>
    /// Сервис отвечающий за отправку E-mail 
    /// </summary>
    public class EmailService
    {
        private string sMtpRef;
        private int port;
        private bool sSL;
        private string password;
        private string fromEmailAddress;
        private bool disconnect;
        /// <summary>
        /// Конструктор для передачи параметров
        /// </summary>
        /// <param name="sMtpRef"></param>
        /// <param name="port"></param>
        /// <param name="sSL"></param>
        /// <param name="password"></param>
        /// <param name="fromEmailAddress"></param>
        /// <param name="disconnect"></param>
        public EmailService(string sMtpRef, int port, bool sSL, string password, string fromEmailAddress, bool disconnect)
        {
            this.sMtpRef = sMtpRef;
            this.port = port;
            this.sSL = sSL;
            this.password = password;
            this.fromEmailAddress = fromEmailAddress;
            this.disconnect = disconnect;
        }

        /// <summary>
        /// Отправка e-mail с помощью SMTP-клиента
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", fromEmailAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(sMtpRef, port, sSL);
                await client.AuthenticateAsync(fromEmailAddress, password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(disconnect);
            }
        }
    }
}
