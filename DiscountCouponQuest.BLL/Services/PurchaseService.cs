using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;

using QuestDAL = DiscountCouponQuest.DAL.Models.Quest;
using CustomerDAL = DiscountCouponQuest.DAL.Models.Customer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiscountCouponQuest.BLL.Services
{
    public class PurchaseService
    {
        private readonly IRepository<QuestDAL> _repository;
        private readonly IRepository<CustomerDAL> _customerRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IRepository<QuestDAL> repository, IRepository<CustomerDAL> customerRepository, IMapper mapper)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task BuyQuestService(int questId, string userId)
        {
            var questToGet = await _repository.GetEntityAsync(q => q.Id.Equals(questId));
            var questPrice = questToGet.Price;
            var customerToGet = await _customerRepository.GetEntityAsync(q => q.UserId.Equals(userId));
            customerToGet.Cash -= questPrice;
            var questBonus = questToGet.Bonus;
            customerToGet.Bonus += questBonus;
            _repository.Update(questToGet);
            _customerRepository.Update(customerToGet);
            await _repository.SaveChangesAsync();

        }

    }
}
