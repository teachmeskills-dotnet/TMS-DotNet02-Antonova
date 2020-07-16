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
