using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using DiscountCouponQuest.BLL.Models;
using DiscountCouponQuest.WebApp.ViewModel;

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
        }
    }
}
