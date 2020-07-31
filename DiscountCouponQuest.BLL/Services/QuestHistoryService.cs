using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.Common.Interfaces;

using QuestHistoryDAL = DiscountCouponQuest.DAL.Models.QuestHistory;
using CustomerDAL = DiscountCouponQuest.DAL.Models.Customer;
using QuestDAL = DiscountCouponQuest.DAL.Models.Quest;
using DiscountCouponQuest.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiscountCouponQuest.BLL.Services
{
    public class QuestHistoryService
    {
        private readonly IRepository<QuestHistoryDAL> _repository;
        private readonly IRepository<QuestDAL> _questRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerDAL> _customerRepository;
        public QuestHistoryService(IRepository<QuestHistoryDAL> repository, IRepository<QuestDAL> questRepository, IMapper mapper, IRepository<CustomerDAL> customerRepository)
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
        public async Task<List<Quest>> GetAllCustomerQuests(string userId)
        {
            var customerToGet = await _customerRepository.GetEntityAsync(q => q.UserId.Equals(userId));
            var questHistoryToGet = _repository.GetAll().Where(q => q.CustomerId.Equals(customerToGet.Id)).Select(q => q.QuestId).ToList();
            var customerQuests = _questRepository.GetAll().Where(q => questHistoryToGet.Contains(q.Id)).ToList();
            var result = _mapper.Map<List<Quest>>(customerQuests);
            return result;
        }
    }
}
