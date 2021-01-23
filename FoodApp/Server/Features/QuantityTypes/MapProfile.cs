using AutoMapper;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Shared.Models.Foods;

namespace FoodApp.Server.Features.QuantityTypes
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<QuantityType, QuantityTypeModel>();
        }
    }
}
