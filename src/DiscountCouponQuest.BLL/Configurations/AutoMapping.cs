using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.DAL.Models;

namespace DiscountCouponQuest.BLL.Configurations
{
    /// <summary>
    /// Автомапинг
    /// </summary>
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<QuestDto, Quest>().ReverseMap();
            CreateMap<ProviderDto, Provider>().ReverseMap();
            CreateMap<Customer, CustomerProfileDto>().ReverseMap();
        }
    }
}
