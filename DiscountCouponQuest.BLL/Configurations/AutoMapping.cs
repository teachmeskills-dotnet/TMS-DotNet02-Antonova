using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using CustomerDAL = DiscountCouponQuest.DAL.Models.Customer;
using QuestDAL = DiscountCouponQuest.DAL.Models.Quest;
using ProviderDAL = DiscountCouponQuest.DAL.Models.Provider;
using System.Linq;

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
            CreateMap<Quest, QuestDAL>();
            CreateMap<QuestDAL, Quest>();
            CreateMap<Provider, ProviderDAL>().ReverseMap();
        }
    }
}

