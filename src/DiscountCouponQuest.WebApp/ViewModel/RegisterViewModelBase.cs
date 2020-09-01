using System.ComponentModel.DataAnnotations;

namespace DiscountCouponQuest.WebApp.ViewModel
{
    /// <summary>
    /// Базовый класс для регистрации пользователя
    /// </summary>

    public class RegisterViewModelBase
    {
        /// <summary>
        /// E-mail
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Потверждение пароля
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
