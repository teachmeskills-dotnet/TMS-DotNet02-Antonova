using AutoMapper;

using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;
using DiscountCouponQuest.DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Services
{
    public class QuestHistoryService : IQuestHistoryService
    {
        private readonly IRepository<QuestHistory> _repository;
        private readonly IRepository<Quest> _questRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _customerRepository;

        public QuestHistoryService(IRepository<QuestHistory> repository, IRepository<Quest> questRepository, IMapper mapper, IRepository<Customer> customerRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _questRepository = questRepository ?? throw new ArgumentNullException(nameof(questRepository));
        }

        public async Task AddDateToStartQuest(string userId, int questHistoryId)
        {
            var customerToGet = await _customerRepository.GetEntityAsync(q => q.UserId.Equals(userId));
            var questHistoryToGet = await _repository.GetEntityAsync(q => q.CustomerId.Equals(customerToGet.Id));
            questHistoryToGet.QuestStart = DateTime.Now;
        }

        public async Task<List<QuestDto>> GetAllCustomerQuests(string userId)
        {
            var customerToGet = await _customerRepository.GetEntityAsync(q => q.UserId.Equals(userId));
            var questHistoryToGet = _repository.GetAll().Where(q => q.CustomerId.Equals(customerToGet.Id)).Select(q => q.QuestId).ToList();
            var customerQuests = _questRepository.GetAll().Where(q => questHistoryToGet.Contains(q.Id)).ToList();
            var result = _mapper.Map<List<QuestDto>>(customerQuests);
            return result;
        }
    }
}
