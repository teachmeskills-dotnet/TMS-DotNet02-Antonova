using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.BLL.Services;
using User = DiscountCouponQuest.DAL.Models.User;
using DiscountCouponQuest.WebApp.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCouponQuest.WebApp.Controllers
{
    /// <summary>
    /// Контроллер Выбор квеста
    /// </summary>
    public class QuestsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly QuestService _questService;
        private readonly ProviderService _providerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="questService"></param>
        public QuestsController(QuestService questService, IMapper mapper, UserManager<User> userManager, ProviderService providerService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _questService = questService ?? throw new ArgumentNullException(nameof(questService));
            _userManager = userManager;
            _providerService = providerService;
        }
        [HttpGet]
        public IActionResult ChooseQuest()
        {
            var listOfQuests = _questService.GetAll();
            var mapQuest = _mapper.Map<List<QuestViewModel>>(listOfQuests);
            return View(mapQuest);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MakeQuest(QuestViewModel makeQuest)
        {
            var quest = _mapper.Map<Quest>(makeQuest);
            var username = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(username);
            var provider = _providerService.GetProviderByUserId(user.Id);
            quest.ProviderId = provider.Id;

            if (makeQuest.ImageFile != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(makeQuest.ImageFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)makeQuest.ImageFile.Length);
                }
                quest.Image = imageData;
            }
            await _questService.AddAsync(quest);
            return View();
        }
        [HttpGet]
        public IActionResult MakeQuest()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditQuest(QuestViewModel editQuest)
        {
            var quest = _mapper.Map<Quest>(editQuest);
            _questService.Edit(quest);
            return View();
        }
    }
}
