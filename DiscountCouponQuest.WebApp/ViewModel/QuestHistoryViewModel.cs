using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.ViewModel
{
    /// <summary>
    /// История квестов
    /// </summary>
    public class QuestHistoryViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата начала квеста
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Статус квеста
        /// </summary>
        public bool IsUsed { get; set; }
        /// <summary>
        /// ID квеста
        /// </summary>
        public int QuestId { get; set; }
    }
}
