using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
        /// Страна
        /// </summary>
        [Display(Name = "Страна")]
        public string Country { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [Display(Name = "Город")]
        public string Town { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [Display(Name = "Улица")]
        public string Street { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        [Display(Name = "Номер дома")]
        public string Number { get; set; }

        public string Address
        {
            get
            {
                return $"{Country}, {Town}, {Street}, {Number}";
            }
        }
    }
}
