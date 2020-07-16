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
        public string Time { get; set; }
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
        /// Длмна маршрута
        /// </summary>
        public string Distance { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Бонусы
        /// </summary>
        public int Bonus { get; set; }
        /// <summary>
        /// Начало квеста
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// Конец квеста
        /// </summary>
        public string Finish { get; set; }

        /// <summary>
        /// ID юридического лица
        /// </summary>
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
