using AutoMapper;
using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.WebApp.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountCouponQuest.WebApp.Configurations
{
    /// <summary>
    /// Автомапинг
    /// </summary>
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<QuestViewModel, Quest>().ReverseMap();
            CreateMap<CustomerProfileViewModel, Customer>().ReverseMap();
            CreateMap<CustomerProfileViewModel, CustomerProfile>().ReverseMap();
            CreateMap<Task<List<Quest>>, List<QuestViewModel>>().ReverseMap();
        }
    }
}
