using DiscountCouponQuest.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.Models
{
    public class User: IDbIdentity
    {
        public int Id { get; set; }
    }
}
