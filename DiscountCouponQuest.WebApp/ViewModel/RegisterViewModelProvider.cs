using System.ComponentModel.DataAnnotations;

namespace DiscountCouponQuest.WebApp.ViewModel
{
    /// <summary>
    /// Регистрация юридических лиц
    /// </summary>

    public class RegisterViewModelProvider : RegisterViewModelBase
    {
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Серийный номер
        /// </summary>
        [Required]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Описание компании
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}
