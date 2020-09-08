using AutoMapper;
using DiscountCouponQuest.BLL.Configurations;
using DiscountCouponQuest.BLL.Interfaces;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.BLL.Repository;
using DiscountCouponQuest.BLL.Services;
using DiscountCouponQuest.Common.Interfaces;
using DiscountCouponQuest.DAL;
using DiscountCouponQuest.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace DiscountCouponQuest.Tests.Services
{
    public class CustomerServiceTests
    {
        private readonly ICustomersService _customersService;
        private readonly IRepository<Customer> _repository;
        private readonly DiscountCouponQuestDbContext _discountCouponQuestDbContext;
        private readonly IMapper _mapper;

        public CustomerServiceTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<DiscountCouponQuestDbContext>(o => o.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            serviceCollection.AddAutoMapper(Assembly.Load("DiscountCouponQuest.BLL"));

            var serviceProvider = serviceCollection.BuildServiceProvider();
            _discountCouponQuestDbContext = serviceProvider.GetRequiredService<DiscountCouponQuestDbContext>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();

            _repository = new Repository<Customer>(_discountCouponQuestDbContext);
            _customersService = new CustomersService(_repository, _mapper);
        }

        [Fact]
        public void Add_WhenNewCustomer_ReturnsNotEmptyCollection()
        {
            // Arrange
            var countBefore = _repository.GetAll().ToList().Count;
            var customerDto = new CustomerDto
            {
                Id = 1,
                Image = new byte[10],
                FirstName = "FirstName",
                MiddleName = "MiddleName",
                LastName = "LastName",
                PhoneNumber = 123123,
                Bonus = 123,
                Cash = 123,
                UserId = "123",
            };

            // Act
            _customersService.AddAsync(customerDto).GetAwaiter().GetResult();
            var countAfter = _repository.GetAll().ToList().Count;

            // Assert
            Assert.NotEqual(countBefore, countAfter);
        }

        [Fact]
        public void Add_WhenNullCustomer_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _customersService.AddAsync(null).GetAwaiter().GetResult());
        }

        [Fact]
        public void GetCustomerByUserId_WhenCustomerIsExist_ReturnsFoundedCustomerDto()
        {
            // Arrange
            var userId = "qwerty123";
            var customer = new Customer
            {
                Id = 1,
                Image = new byte[10],
                FirstName = "FirstName",
                MiddleName = "MiddleName",
                LastName = "LastName",
                PhoneNumber = 123123,
                Bonus = 123,
                Cash = 123,
                UserId = userId,
            };
            _repository.AddAsync(customer).GetAwaiter().GetResult();
            _repository.SaveChangesAsync().GetAwaiter().GetResult();

            // Act
            var customerDto = _customersService.GetCustomerByUserId(userId).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(customerDto);
            Assert.Equal(userId, customerDto.UserId);
        }

        [Fact]
        public void GetCustomerByUserId_WhenUserIdIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _customersService.GetCustomerByUserId(null).GetAwaiter().GetResult());
        }

        [Fact]
        public void GetCustomerByUserId_WhenEmptyCollection_ThrowsArgumentNullException()
        {
            // Arrange
            var userId = "qwerty123";

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => _customersService.GetCustomerByUserId(userId).GetAwaiter().GetResult());
        }

        [Fact]
        public void GetCustomerByUserId_WhenCustomerIsNotExist_ThrowsArgumentNullException()
        {
            // Arrange
            var userId = "qwerty123";
            var customer = new Customer
            {
                Id = 1,
                Image = new byte[10],
                FirstName = "FirstName",
                MiddleName = "MiddleName",
                LastName = "LastName",
                PhoneNumber = 123123,
                Bonus = 123,
                Cash = 123,
                UserId = "qwerty1234",
            };
            _repository.AddAsync(customer).GetAwaiter().GetResult();
            _repository.SaveChangesAsync().GetAwaiter().GetResult();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => _customersService.GetCustomerByUserId(userId).GetAwaiter().GetResult());
        }
    }
}
