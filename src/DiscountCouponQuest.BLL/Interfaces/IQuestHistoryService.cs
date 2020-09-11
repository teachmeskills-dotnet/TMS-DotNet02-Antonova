using DiscountCouponQuest.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface IQuestHistoryService
    {
        Task AddDateToStartQuest(string userId, int questHistoryId);

        Task<List<QuestDto>> GetAllCustomerQuests(string userId);
    }
}