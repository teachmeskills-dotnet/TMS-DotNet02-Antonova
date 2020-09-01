using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;
using DiscountCouponQuest.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Services
{
    /// <summary>
    /// Сервис для квестов
    /// </summary>
    public class QuestService
    {
        private readonly IRepository<Quest> _repository;
        private readonly IMapper _mapper;

        public QuestService(IRepository<Quest> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<QuestDto>> GetAllAsync()
        {
            var allQuests = await _repository.GetAll().AsNoTracking().ToListAsync();
            var result = _mapper.Map<List<QuestDto>>(allQuests);
            return result;
        }

        public async Task AddAsync(QuestDto quest)
        {
            var dataModel = _mapper.Map<Quest>(quest);
            await _repository.AddAsync(dataModel);
            await _repository.SaveChangesAsync();
        }

        public async Task Edit(QuestDto quest)
        {
            var questToEdit = await _repository.GetEntityAsync(q => q.Id.Equals(quest.Id));
            questToEdit.Image = quest.Image;
            questToEdit.Name = quest.Name;
            questToEdit.Description = quest.Description;
            questToEdit.Distance = quest.Distance;
            questToEdit.Time = quest.Time;
            questToEdit.Price = quest.Price;
            questToEdit.Country = quest.Country;
            questToEdit.Town = quest.Town;
            questToEdit.Street = quest.Street;
            questToEdit.Number = quest.Number;
            questToEdit.Bonus = quest.Bonus;
            _repository.Update(questToEdit);
            await _repository.SaveChangesAsync();
        }

        public async Task<QuestDto> GetQuestById(int id)
        {
            var questToGet = await _repository.GetEntityAsync(q => q.Id.Equals(id));
            var result = _mapper.Map<QuestDto>(questToGet);
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
