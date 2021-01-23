using AutoMapper;
using FoodApp.Core.Domain.Foods;
using FoodApp.Shared.Models.Foods;

namespace FoodApp.Server.Features.Foods
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Food, FoodModel>()
                .ForMember(d => d.QuanityType, o => o.MapFrom(s => s.QuantityType.Type));
        }
    }
}
