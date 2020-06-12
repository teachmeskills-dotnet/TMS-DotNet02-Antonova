using DiscountCouponQuest.Common.Interfaces;
using System.Collections.Generic;

namespace DiscountCouponQuest.DAL.Models
{
    public class Coupon : IDbIdentity, IDescription, IName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string UniqueCode { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public List<CouponHistory> CouponHistories { get; set; }
    }
}
