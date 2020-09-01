using AutoMapper;
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
    /// Сервис юридического лица
    /// </summary>
    public class ProviderService
    {
        private readonly IRepository<Provider> _repository;
        private readonly IMapper _mapper;

        public ProviderService(IRepository<Provider> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddAsync(ProviderDto provider)
        {
            var dataModel = _mapper.Map<Provider>(provider);
            await _repository.AddAsync(dataModel);
            await _repository.SaveChangesAsync();
        }

        public ProviderDto GetProviderByUserId(string userId)
        {
            var providers = _repository.GetAll().AsNoTracking().ToList();
            var providerDataModel = providers.FirstOrDefault(c => c.UserId.Equals(userId, StringComparison.InvariantCultureIgnoreCase));
            if (providerDataModel is null)
            {
                throw new Exception();
            }

            var provider = _mapper.Map<ProviderDto>(providerDataModel);
            provider.Id = providerDataModel.Id;
            return provider;
        }
    }
}
