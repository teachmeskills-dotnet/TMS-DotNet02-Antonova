using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Interfaces
{
    /// <summary>
    /// Сервис отвечающий за отправку E-mail.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Отправка e-mail с помощью SMTP-клиента.
        /// </summary>
        /// <param name="email">Почта.</param>
        /// <param name="subject">Тема.</param>
        /// <param name="message">Сообщение.</param>
        Task SendEmailAsync(string email, string subject, string message);
    }
}
