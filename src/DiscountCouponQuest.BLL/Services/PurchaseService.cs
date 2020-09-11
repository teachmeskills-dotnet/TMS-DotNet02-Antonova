using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.Common.Interfaces;
using DiscountCouponQuest.DAL.Models;
using System;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepository<Quest> _repository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<QuestHistory> _historyRepository;

        public PurchaseService(IRepository<Quest> repository, IRepository<Customer> customerRepository, IRepository<QuestHistory> historyRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
        }

        public async Task BuyQuestService(int questId, string userId)
        {
            var questToGet = await _repository.GetEntityAsync(q => q.Id.Equals(questId));
            var questPrice = questToGet.Price;
            var customerToGet = await _customerRepository.GetEntityAsync(q => q.UserId.Equals(userId));
            if (questToGet.Price < customerToGet.Cash)
            {
                customerToGet.Cash -= questPrice;
                var questBonus = questToGet.Bonus;
                customerToGet.Bonus += questBonus;
                var questHistoryDAL = new QuestHistory
                {
                    CustomerId = customerToGet.Id,
                    QuestId = questToGet.Id
                };
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
