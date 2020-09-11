using DiscountCouponQuest.BLL.Models;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface IProviderService
    {
        Task AddAsync(ProviderDto provider);

        ProviderDto GetProviderByUserId(string userId);
    }
}