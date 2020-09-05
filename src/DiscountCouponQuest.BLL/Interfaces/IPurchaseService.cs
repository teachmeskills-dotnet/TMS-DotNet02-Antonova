using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface IPurchaseService
    {
        Task BuyQuestService(int questId, string userId);
    }
}