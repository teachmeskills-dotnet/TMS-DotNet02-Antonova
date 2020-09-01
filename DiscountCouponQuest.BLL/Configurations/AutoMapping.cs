using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using CustomerDAL = DiscountCouponQuest.DAL.Models.Customer;
using ProviderDAL = DiscountCouponQuest.DAL.Models.Provider;
using QuestDAL = DiscountCouponQuest.DAL.Models.Quest;

namespace DiscountCouponQuest.BLL.Configurations
{
    /// <summary>
    /// Автомапинг
    /// </summary>
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, CustomerDAL>().ReverseMap();
            CreateMap<Quest, QuestDAL>().ReverseMap();
            CreateMap<Provider, ProviderDAL>().ReverseMap();
            CreateMap<CustomerProfile, CustomerDAL>();
            CreateMap<CustomerDAL, CustomerProfile>().ReverseMap();
        }
    }
}
