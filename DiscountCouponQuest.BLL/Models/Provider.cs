using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCouponQuest.BLL.Models
{
    /// <summary>
    /// Юридическое лицо
    /// </summary>
    public class Provider
    {
        public Provider(string id)
        {
            UserId = id;
        }
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ID пользователя
        /// </summary>
        public string UserId { get; set; }
        public Provider()
        {

        }
    }
}
