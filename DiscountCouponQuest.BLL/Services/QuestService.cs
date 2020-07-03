using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;

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
            _repository = repository;
            _mapper = mapper;
        }

        public List<Quest> GetAll()
        {
            var allQuests = _repository.GetAll().ToList();
            var result = _mapper.Map<List<Quest>>(allQuests);
            return result;
        }
        public async Task AddAsync(Quest quest)
        {
            var dataModel = _mapper.Map<QuestDAL>(quest);
            await _repository.AddAsync(dataModel);
            await _repository.SaveChangesAsync();
        }
        public void Edit(Quest quest)
        {
            var dataModel = _mapper.Map<QuestDAL>(quest);
            _repository.Update(dataModel);
            _repository.SaveChangesAsync();
        }
    }
}
