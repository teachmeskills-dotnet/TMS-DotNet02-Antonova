using System.Collections.Generic;
using System.Threading.Tasks;

using DiscountCouponQuest.BLL.Models;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface IQuestHistoryService
    {
        Task AddDateToStartQuest(string userId, int questHistoryId);
        Task<List<QuestDto>> GetAllCustomerQuests(string userId);
    }
}