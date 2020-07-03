using System.Collections.Generic;

namespace DiscountCouponQuest.DAL.Models
{
    /// <summary>
    /// Квест
    /// </summary>
    public class Quest
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Скидка
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Уникальный номер
        /// </summary>
        public string UniqueCode { get; set; }
       /// <summary>
       /// Изображение
       /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// ID юридического лица
        /// </summary>
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public List<QuestHistory> QuestHistories { get; set; }
    }
}
