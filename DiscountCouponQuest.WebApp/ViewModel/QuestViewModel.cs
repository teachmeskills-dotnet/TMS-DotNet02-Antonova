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
        /// Время прохождения квеста
        /// </summary>
        [Required]
        [Display(Name = "Время прохождения")]
        public string Time { get; set; }

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
        /// <summary>
        /// Длмна маршрута
        /// </summary>
        [Display(Name = "Длина маршрута")]
        public string Distance { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }
        /// <summary>
        /// Бонусы
        /// </summary>
        [Required]
        [Display(Name = "Бонусы")]
        public int Bonus { get; set; }
        /// <summary>
        /// Начало квеста
        /// </summary>
        [Display(Name = "Начало квеста")]
        public string Start { get; set; }
        /// <summary>
        /// Конец квеста
        /// </summary>
        [Display(Name = "Конец квеста")]
        public string Finish { get; set; }
    }
}
