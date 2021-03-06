﻿namespace DiscountCouponQuest.BLL.Models
{
    /// <summary>
    /// Квест
    /// </summary>
    public class QuestDto
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
        /// Страна
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        /// 
        public string Town { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// ID юридического лица
        /// </summary>
        public int ProviderId { get; set; }

        public ProviderDto Provider { get; set; }
    }
}
