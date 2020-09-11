using System;

namespace DiscountCouponQuest.BLL.Models
{
    public class QuestHistoryDto
    {
        public int Id { get; set; }

        public DateTime QuestStart { get; set; }

        public bool IsPassed { get; set; }

        public int QuestId { get; set; }

        public QuestDto Quest { get; set; }

        public int CustomerId { get; set; }

        public CustomerDto Customer { get; set; }
    }
}
