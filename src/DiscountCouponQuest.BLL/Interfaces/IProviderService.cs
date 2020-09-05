using System.Threading.Tasks;

using DiscountCouponQuest.BLL.Models;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface IProviderService
    {
        Task AddAsync(ProviderDto provider);
        ProviderDto GetProviderByUserId(string userId);
    }
}