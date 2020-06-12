﻿using DiscountCouponQuest.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.Models
{
    public class CouponHistory : IDbIdentity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsUsed { get; set; }

        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
 