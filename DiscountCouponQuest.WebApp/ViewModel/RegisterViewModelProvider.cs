using System.ComponentModel.DataAnnotations;

namespace DiscountCouponQuest.WebApp.ViewModel
{
    /// <summary>
    /// Регистрация юридических лиц
    /// </summary>

    public class RegisterViewModelProvider : RegisterViewModelBase
    {

        /// <summary>
        /// Серийный номер
        /// </summary>
        [Required]
        public string SerialNumber { get; set; }

    }
}
