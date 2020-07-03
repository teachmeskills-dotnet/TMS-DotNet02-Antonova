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

        public string Name { get; set; }

        /// <summary>
        /// Предоставляемая скидка
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Описание квеста
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///Статус квеста
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Уникальный номер квеста
        /// </summary>
        public string UniqueCode { get; set; }
    }
}
