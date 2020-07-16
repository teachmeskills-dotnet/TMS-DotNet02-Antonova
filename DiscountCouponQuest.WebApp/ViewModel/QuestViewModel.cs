using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace DiscountCouponQuest.WebApp.ViewModel
{
    /// <summary>
    /// Выбор квеста
    /// </summary>

    public class QuestViewModel
    {
        /// <summary>
        /// ID квеста
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// Название квеста
        /// </summary>

        [Required]
        [Display(Name = "Название квеста")]
        public string Name { get; set; }

        /// <summary>
        /// Предоставляемая скидка
        /// </summary>
        [Required]
        [Display(Name = "Предоставляемая скидка")]
        public int Discount { get; set; }

        /// <summary>
        /// Описание квеста
        /// </summary>
        [Required]
        [Display(Name = "Описание квеста")]
        public string Description { get; set; }

        /// <summary>
        /// Изображение
        /// </summary>
        [Display(Name = "Загрузить изображение")]
        public IFormFile ImageFile { get; set; }

        /// <summary>
        /// Уникальный номер квеста
        /// </summary>
        [Required]
        [Display(Name = "Уникальный номер квеста")]
        public string UniqueCode { get; set; }

        public byte[] Image { get; set; }
    }
}
