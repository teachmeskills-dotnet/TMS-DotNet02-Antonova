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
            CreateMap<QuestViewModel, QuestDto>().ReverseMap();
            CreateMap<CustomerProfileViewModel, CustomerDto>().ReverseMap();
            CreateMap<CustomerProfileViewModel, CustomerProfileDto>().ReverseMap();
            CreateMap<Task<List<QuestDto>>, List<QuestViewModel>>().ReverseMap();
        }
    }
}
