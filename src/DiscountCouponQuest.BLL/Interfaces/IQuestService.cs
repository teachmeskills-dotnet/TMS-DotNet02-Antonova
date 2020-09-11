using DiscountCouponQuest.BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface IQuestService
    {
        Task AddAsync(QuestDto quest);

        Task DeleteQuest(int id);

        Task Edit(QuestDto quest);

        Task<List<QuestDto>> GetAllAsync();

        Task<QuestDto> GetQuestById(int id);
    }
}