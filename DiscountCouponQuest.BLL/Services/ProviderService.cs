using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.Common.Interfaces;
using ProviderDAL = DiscountCouponQuest.DAL.Models.Provider;

namespace DiscountCouponQuest.BLL.Services
{
    /// <summary>
    /// Сервис юридического лица
    /// </summary>
    public class ProviderService
    {
        private readonly IRepository<ProviderDAL> _repository;
        private readonly IMapper _mapper;
        public ProviderService(IRepository<ProviderDAL> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(Provider provider)
        {
            var dataModel = _mapper.Map<ProviderDAL>(provider);
            await _repository.AddAsync(dataModel);
            await _repository.SaveChangesAsync();
        }

        public Provider GetProviderByUserId(string userId)
        {
            var providers = _repository.GetAll().ToList();
            var providerDataModel = providers.FirstOrDefault(c => c.UserId.Equals(userId, StringComparison.InvariantCultureIgnoreCase));
            if(providerDataModel is null)
            {
                throw new Exception();
            }

            var provider = _mapper.Map<Provider>(providerDataModel);
            provider.Id = providerDataModel.Id;
            return provider;
        }
    }
}
