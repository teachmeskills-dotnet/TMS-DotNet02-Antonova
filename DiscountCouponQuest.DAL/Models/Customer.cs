﻿using System.Collections.Generic;

namespace DiscountCouponQuest.DAL.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        public string UserId { get; set; }

        public List<QuestHistory> CouponHistories { get; set; }

        public Customer(string userId)
        {
            UserId = userId;
        }
    }
}
