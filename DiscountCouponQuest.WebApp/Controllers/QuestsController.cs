using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.BLL.Services;
using DiscountCouponQuest.WebApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiscountCouponQuest.WebApp.Controllers
{
    /// <summary>
    /// Контроллер Выбор квеста
    /// </summary>
    public class QuestsController : Controller
    {
        private readonly QuestService _questService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="questService"></param>
        public QuestsController(QuestService questService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _questService = questService ?? throw new ArgumentNullException(nameof(questService));
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
        public async Task<IActionResult> MakeQuestAsync(QuestViewModel makeQuest)
        {
            var quest = _mapper.Map<Quest>(makeQuest);
            await _questService.AddAsync(quest);
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
