using System;

namespace DiscountCouponQuest.DAL.Models
{
    public class QuestHistory
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsUsed { get; set; }

        public int CouponId { get; set; }
        public Quest Coupon { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
