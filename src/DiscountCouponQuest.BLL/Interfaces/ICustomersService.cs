using System.Threading.Tasks;

using DiscountCouponQuest.BLL.Models;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface ICustomersService
    {
        Task AddAsync(CustomerDto customer);
        Task Edit(CustomerProfileDto customer);
        Task<CustomerDto> GetCustomerByUserId(string userId);
    }
}