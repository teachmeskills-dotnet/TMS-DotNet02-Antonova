using System.Collections.Generic;

namespace DiscountCouponQuest.DAL.Models
{
    /// <summary>
    /// Юридическое лицо
    /// </summary>
    public class Provider
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
        /// Серийный номер
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID пользователя
        /// </summary>
        public string UserId { get; set; }

        public List<Quest> Quests { get; set; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userId"></param>
        public Provider(string userId)
        {
            UserId = userId;
        }
        public Provider()
        {

        }
    }
}
