using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.BLL.Services;
using DiscountCouponQuest.WebApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using User = DiscountCouponQuest.DAL.Models.User;

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
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _providerService = providerService ?? throw new ArgumentNullException(nameof(providerService));
        }

        [HttpGet]
        public async Task<IActionResult> ChooseQuestAsync()
        {
            var listOfQuests = await _questService.GetAllAsync();
            var mapQuest = _mapper.Map<List<QuestViewModel>>(listOfQuests);
            return View(mapQuest);
        }

        [HttpPost]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> MakeQuest(QuestViewModel makeQuest)
        {
            var quest = _mapper.Map<QuestDto>(makeQuest);
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
            return RedirectToAction("ChooseQuest");
        }

        [HttpGet]
        public IActionResult MakeQuest()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditQuest(int id)
        {
            var quest = await _questService.GetQuestById(id);
            var model = _mapper.Map<QuestViewModel>(quest);
            return View(model);
        }

        public async Task<IActionResult> DetailsQuest(int id)
        {
            var quest = await _questService.GetQuestById(id);
            var model = _mapper.Map<QuestViewModel>(quest);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Provider")]
        public async Task<IActionResult> EditQuest(QuestViewModel editQuest)
        {
            var quest = _mapper.Map<QuestDto>(editQuest);
            if (editQuest.ImageFile != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(editQuest.ImageFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)editQuest.ImageFile.Length);
                }
                quest.Image = imageData;
                await _questService.Edit(quest);
            }
            else
            {
                editQuest.Image = quest.Image;
            }
            return RedirectToAction("ChooseQuest");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DeleteQuest(int id)
        {
            await _questService.DeleteQuest(id);
            return RedirectToAction("ChooseQuest");
        }

        public IActionResult GoogleMap()
        {
            return View();
        }

        public async Task<IActionResult> SearchQuest(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var listOfQuests = await _questService.GetAllAsync();
                var questToSearch = listOfQuests.Where(q => q.Name.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
                var mapQuest = _mapper.Map<List<QuestViewModel>>(questToSearch);
                return View("ChooseQuest", mapQuest);
            }
            else
            {
                return Content("Такого квеста не существует. Повторите поиск");
            }
        }
    }
}