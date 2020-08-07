using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;

using QuestDAL = DiscountCouponQuest.DAL.Models.Quest;
using CustomerDAL = DiscountCouponQuest.DAL.Models.Customer;
using QuestHistoryDAL = DiscountCouponQuest.DAL.Models.QuestHistory;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiscountCouponQuest.BLL.Services
{
    public class PurchaseService
    {
        private readonly IRepository<QuestDAL> _repository;
        private readonly IRepository<CustomerDAL> _customerRepository;
        private readonly IRepository<QuestHistoryDAL> _historyRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IRepository<QuestDAL> repository, IRepository<CustomerDAL> customerRepository, IRepository<QuestHistoryDAL> historyRepository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
        }
        public async Task BuyQuestService(int questId, string userId)
        {
            var questToGet = await _repository.GetEntityAsync(q => q.Id.Equals(questId));
            var questPrice = questToGet.Price;
            var customerToGet = await _customerRepository.GetEntityAsync(q => q.UserId.Equals(userId));
            if (questToGet.Price<customerToGet.Cash)
            {
                customerToGet.Cash -= questPrice;
                var questBonus = questToGet.Bonus;
                customerToGet.Bonus += questBonus;
                QuestHistoryDAL questHistoryDAL = new QuestHistoryDAL();
                questHistoryDAL.CustomerId = customerToGet.Id;
                questHistoryDAL.QuestId = questToGet.Id;
                _repository.Update(questToGet);
                _customerRepository.Update(customerToGet);
                await _historyRepository.AddAsync(questHistoryDAL);
                await _customerRepository.SaveChangesAsync();
                await _historyRepository.SaveChangesAsync();
                await _repository.SaveChangesAsync();
            }
            else
            {
                throw new Exception("У вас недостаточно денег на счету");
            }
        }
    }
}
