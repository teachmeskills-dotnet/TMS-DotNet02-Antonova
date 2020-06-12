using DiscountCouponQuest.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCouponQuest.DAL.Models
{
    public class User:IDbIdentity
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public List<Customer> Customers { get; set; }
        public List<Provider> Providers { get; set; }
    }
}
