using System.Threading.Tasks;
using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;
using CustomerDAL = DiscountCouponQuest.DAL.Models.Customer;

namespace DiscountCouponQuest.BLL.Services
{
    public class CustomersService
    {
        private readonly IRepository<CustomerDAL> _repository;
        private readonly IMapper _mapper;
        public CustomersService(IRepository<CustomerDAL> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(Customer customer)
        {
            var dataModel = _mapper.Map<CustomerDAL>(customer);
            await _repository.AddAsync(dataModel);
            await _repository.SaveChangesAsync();
        }
    }
}
