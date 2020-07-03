using System.Collections.Generic;

namespace DiscountCouponQuest.DAL.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }

        public List<Quest> Coupons { get; set; }
        public Provider(string userId)
        {
            UserId = userId;
        }
    }
}
