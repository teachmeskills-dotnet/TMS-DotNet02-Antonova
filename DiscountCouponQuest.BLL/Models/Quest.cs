namespace DiscountCouponQuest.BLL.Models
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
        /// Статус квеста
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Уникальный номер
        /// </summary>
        public string UniqueCode { get; set; }
        /// <summary>
        /// ID юридического лица
        /// </summary>
        public int ProviderId { get; set; }
    }
}
