using DiscountCouponQuest.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscountCouponQuest.DAL
{
    public class DiscountCouponQuestDbContext : DbContext
    {
        public DiscountCouponQuestDbContext()
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponHistory> CouponHistories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(("Server=(localdb)\\mssqllocaldb;Database=QuestTest;Trusted_Connection=True;MultipleActiveResultSets=true"));

        }
    }
}