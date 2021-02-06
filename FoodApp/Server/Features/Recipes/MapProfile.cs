using AutoMapper;
using FoodApp.Core.Domain.Foods;
using FoodApp.Shared.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
