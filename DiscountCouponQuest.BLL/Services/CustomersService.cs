using System;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;

using Microsoft.EntityFrameworkCore;

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

        public async Task<Customer> GetCustomerByUserId(string userId)
        {
            var customers = _repository.GetAll().AsNoTracking().ToList();
            var customerDataModel = customers.FirstOrDefault(c => c.UserId.Equals(userId, StringComparison.InvariantCultureIgnoreCase));
            if (customerDataModel is null)
            {
                throw new ArgumentNullException();
            }
            var customer = _mapper.Map<Customer>(customerDataModel);
            customer.Id = customerDataModel.Id;
            return customer;
        }
        public async Task Edit(CustomerProfile customer)
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
