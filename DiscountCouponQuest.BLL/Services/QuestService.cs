using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

using QuestDAL = DiscountCouponQuest.DAL.Models.Quest;

namespace DiscountCouponQuest.BLL.Services
{
    /// <summary>
    /// Сервис для квестов
    /// </summary>
    public class QuestService
    {
        private readonly IRepository<QuestDAL> _repository;
        private readonly IMapper _mapper;

        public QuestService(IRepository<QuestDAL> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<Quest> GetAll()
        {
            var allQuests = _repository.GetAll().AsNoTracking().ToList();
            var result = _mapper.Map<List<Quest>>(allQuests);
            return result;
        }
        public async Task AddAsync(Quest quest)
        {
            var dataModel = _mapper.Map<QuestDAL>(quest);
            await _repository.AddAsync(dataModel);
            await _repository.SaveChangesAsync();
        }
        public async Task Edit(Quest quest)
        {
            var questToEdit = await _repository.GetEntityAsync(q => q.Id.Equals(quest.Id));
            questToEdit.Image = quest.Image;
            questToEdit.Name = quest.Name;
            questToEdit.Description = quest.Description;
            questToEdit.Distance = quest.Distance;
            questToEdit.Time = quest.Time;
            questToEdit.Price = quest.Price;
            questToEdit.Start = quest.Start;
            questToEdit.Finish = quest.Finish;
            questToEdit.Bonus = quest.Bonus;
            _repository.Update(questToEdit);
            await _repository.SaveChangesAsync();
        }
        public async Task<Quest> GetQuestById(int id)
        {
            var questToGet = await _repository.GetEntityAsync(q => q.Id.Equals(id));
            var result = _mapper.Map<Quest>(questToGet);
            result.Id = questToGet.Id;
            return result;
        }
        public async Task DeleteQuest(int id)
        {
            var all = _repository.GetAll().ToList();
            var questToDelete = await _repository.GetEntityAsync(q => q.Id.Equals(id));
            _repository.Delete(questToDelete);
            await _repository.SaveChangesAsync();
        }
    }
}
