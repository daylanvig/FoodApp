using AutoMapper;
using FoodApp.Core.Domain.Foods;
using FoodApp.Shared.Models.Recipes;

namespace FoodApp.Server.Features.Recipes
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Recipe, RecipeModel>();
        }
    }
}
