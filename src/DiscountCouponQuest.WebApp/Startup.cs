using AutoMapper;
using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.BLL.Repository;
using DiscountCouponQuest.BLL.Services;
using DiscountCouponQuest.Common.Helpers;
using DiscountCouponQuest.Common.Interfaces;
using DiscountCouponQuest.DAL;
using DiscountCouponQuest.DAL.Models;
using DiscountCouponQuest.WebApp.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMappingBLL = DiscountCouponQuest.BLL.Configurations.AutoMapping;

namespace DiscountCouponQuest.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<DiscountCouponQuestDbContext>().AddDefaultTokenProviders();
            services.AddDbContext<DiscountCouponQuestDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<ICustomersService,CustomersService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IQuestService, QuestService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IQuestHistoryService, QuestHistoryService>();

            services.AddAutoMapper(c => 
            { 
                c.AddProfile<AutoMappingBLL>();
                c.AddProfile<AutoMapping>();
            },
            typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
