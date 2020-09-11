using DiscountCouponQuest.BLL.Models;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Interfaces
{
    public interface ICustomersService
    {
        Task AddAsync(CustomerDto customer);

        Task Edit(CustomerProfileDto customer);

        Task<CustomerDto> GetCustomerByUserId(string userId);
    }
}