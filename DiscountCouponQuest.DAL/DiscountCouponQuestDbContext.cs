using DiscountCouponQuest.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscountCouponQuest.DAL
{
    public class DiscountCouponQuestDbContext : IdentityDbContext<User>
    {
        public DiscountCouponQuestDbContext(DbContextOptions<DiscountCouponQuestDbContext> options)
            : base(options)
        {
        }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestHistory> QuestHistories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}