using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using User = DiscountCouponQuest.DAL.Models.User;
using DiscountCouponQuest.BLL.Services;
using DiscountCouponQuest.WebApp.ViewModel;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DiscountCouponQuest.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace DiscountCouponQuest.WebApp.Controllers
{
    /// <summary>
    /// Контроллер профиль
    /// </summary>
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly CustomersService _customerService;
        private readonly IMapper _mapper;
        private readonly QuestHistoryService _questHistoryService;
        public ProfileController(IMapper mapper, UserManager<User> userManager, CustomersService customerService, QuestHistoryService questHistoryService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _questHistoryService = questHistoryService ?? throw new ArgumentNullException(nameof(questHistoryService));
        }
        public async Task<IActionResult> CustomerProfile()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var customer = await _customerService.GetCustomerByUserId(user.Id);
            var model = _mapper.Map<CustomerProfileViewModel>(customer);
            return View(model);
        }
        public async Task<IActionResult> EditCustomerProfile()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var customer = await _customerService.GetCustomerByUserId(user.Id);
            var model = _mapper.Map<CustomerProfileViewModel>(customer);
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditCustomerProfile(CustomerProfileViewModel editCustomerProfile)
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var customer = await _customerService.GetCustomerByUserId(user.Id);
            var profile = _mapper.Map<CustomerProfile>(editCustomerProfile);
            if (editCustomerProfile.ImageFile != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(editCustomerProfile.ImageFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)editCustomerProfile.ImageFile.Length);
                }
                profile.Image = imageData;
            }
            else
            {
                profile.Image = customer.Image;
            }
            await _customerService.Edit(profile);
            return RedirectToAction("CustomerProfile");
                                                        }
        public async Task<IActionResult> QuestHistory()
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var listOfQuests = await _questHistoryService.GetAllCustomerQuests(user.Id);
            var mapQuest = _mapper.Map<List<QuestViewModel>>(listOfQuests);
            return View(mapQuest);
        }
        public async Task<IActionResult> StartQuest(int questHistoryId)
        {
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var customer = await _customerService.GetCustomerByUserId(user.Id);
            await _questHistoryService.AddDateToStartQuest(user.Id, questHistoryId);
            return RedirectToAction("CustomerProfile", "Profile");
        }

    }
}
