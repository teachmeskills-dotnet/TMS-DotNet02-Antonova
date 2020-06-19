using System;

namespace DiscountCouponQuest.DAL.Models
{
    public class CouponHistory
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsUsed { get; set; }

        public string CouponId { get; set; }
        public Coupon Coupon { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
