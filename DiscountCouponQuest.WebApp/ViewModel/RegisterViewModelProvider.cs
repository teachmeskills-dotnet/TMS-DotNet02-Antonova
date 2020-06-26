using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
