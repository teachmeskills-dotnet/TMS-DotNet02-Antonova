using DiscountCouponQuest.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCouponQuest.DAL.Models
{
    public class Provider : IDbIdentity, IName, IDescription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Coupon> Coupons { get; set; }
    }
}
