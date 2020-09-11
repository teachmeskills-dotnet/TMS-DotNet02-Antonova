using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.Controllers
{
    /// <summary>
    /// Покупка квеста
    /// </summary>
    public class PurchaseController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPurchaseService _purchaseService;
        private readonly ICustomersService _customerService;

        public PurchaseController(IPurchaseService purchaseService, UserManager<User> userManager, ICustomersService customerService)
        {
            _purchaseService = purchaseService ?? throw new ArgumentNullException(nameof(purchaseService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        public async Task<IActionResult> BuyQuest(int questId)
        {
            try
            {
                var username = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(username);
                var customer = await _customerService.GetCustomerByUserId(user.Id);
                await _purchaseService.BuyQuestService(questId, user.Id);
                return RedirectToAction("CustomerProfile", "Profile");
            }
            catch (Exception)
            {
                return Content("У вас недостаточно денег на счету");
            }
        }
    }
}
