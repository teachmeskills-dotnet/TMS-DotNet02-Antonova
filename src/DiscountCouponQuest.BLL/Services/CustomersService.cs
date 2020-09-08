using AutoMapper;

using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;
using DiscountCouponQuest.DAL.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountCouponQuest.BLL.Services
{
    /// <summary>
    /// Сервис отвечающий за работу с юзером
    /// </summary>
    public class CustomersService : ICustomersService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomersService(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddAsync(CustomerDto customer)
        {
            customer = customer ?? throw new ArgumentNullException(nameof(customer));

            var dataModel = _mapper.Map<Customer>(customer);
            await _repository.AddAsync(dataModel);
            await _repository.SaveChangesAsync();
        }

        public async Task<CustomerDto> GetCustomerByUserId(string userId)
        {
            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var customers = await _repository.GetAll().AsNoTracking().ToListAsync();
            var customerDataModel = customers.FirstOrDefault(c => c.UserId.Equals(userId, StringComparison.InvariantCultureIgnoreCase));
            if (customerDataModel is null)
            {
                throw new ArgumentNullException();
            }
            var customer = _mapper.Map<CustomerDto>(customerDataModel);
            customer.Id = customerDataModel.Id;
            return customer;
        }

        public async Task Edit(CustomerProfileDto customer)
        {
            var customerToEdit = await _repository.GetEntityAsync(q => q.Id.Equals(customer.Id));
            customerToEdit.Image = customer.Image;
            customerToEdit.FirstName = customer.FirstName;
            customerToEdit.MiddleName = customer.MiddleName;
            customerToEdit.LastName = customer.LastName;
            customerToEdit.PhoneNumber = customer.PhoneNumber;
            customerToEdit.Cash = customer.Cash;
            _repository.Update(customerToEdit);
            await _repository.SaveChangesAsync();
        }
    }
}
