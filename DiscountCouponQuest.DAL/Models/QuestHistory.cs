using System;

namespace DiscountCouponQuest.DAL.Models
{
    public class QuestHistory
    {
        public int Id { get; set; }
        public DateTime QuestPassing { get; set; }
        public bool IsUsed { get; set; }

        public int QuestId { get; set; }
        public Quest Quest { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
