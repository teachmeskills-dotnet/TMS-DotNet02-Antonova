using DiscountCouponQuest.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.Extensions
{
    /// <summary>
    /// Инициализация БД ролями и пользователями
    /// </summary>
    public class RoleInitializer
    {
        /// <summary>
        ///  Инициализация ролями пользователь и юридическое лицо
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <returns></returns>
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("Provider") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Provider"));
            }
            if (await roleManager.FindByNameAsync("Customer") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }
        }
    }
}
