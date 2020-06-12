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

        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponHistory> CouponHistories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}