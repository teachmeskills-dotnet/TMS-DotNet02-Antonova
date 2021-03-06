﻿using System;

namespace DiscountCouponQuest.DAL.Models
{
    public class QuestHistory
    {
        public int Id { get; set; }

        public DateTime? QuestStart { get; set; }

        public bool IsPassed { get; set; }

        public int QuestId { get; set; }

        public Quest Quest { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
