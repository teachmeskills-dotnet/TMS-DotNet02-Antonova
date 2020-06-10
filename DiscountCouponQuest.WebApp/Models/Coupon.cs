using DiscountCouponQuest.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.Models
{
    public class Coupon : IDbIdentity,IDescription,IName
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string UniqueCode { get; set; }
    }
}
