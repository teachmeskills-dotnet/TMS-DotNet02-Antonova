using System.ComponentModel.DataAnnotations;

namespace DiscountCouponQuest.WebApp.ViewModel
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>

    public class RegisterViewModelCustomer : RegisterViewModelBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [Required]
        public int PhoneNumber { get; set; }
    }
}
