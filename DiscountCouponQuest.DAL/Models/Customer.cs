using DiscountCouponQuest.Common.Interfaces;
using System.Collections.Generic;

namespace DiscountCouponQuest.DAL.Models
{
    public class Customer : IDbIdentity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public int UserId { get; set; }

        public List<CouponHistory> CouponHistories { get; set; }
    }
}
