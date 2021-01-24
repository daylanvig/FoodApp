using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Recipes
{
    public class RecipeIngredientRowBase : ComponentBase
    {
        [Inject]
        IApiRequestService ApiRequestService { get; set; }
        [Parameter] 
        public RecipeIngredientModel RecipeIngredient { get; set; }

        protected RecipeIngredientModel recipeIngredient;
        protected IReadOnlyList<FoodModel> foods = Array.Empty<FoodModel>();
        protected IReadOnlyList<QuantityTypeModel> quantityTypes = Array.Empty<QuantityTypeModel>();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            recipeIngredient = RecipeIngredient;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            // todo -> at some point cache these so they aren't loaded every single time
            foods = await ApiRequestService.GetList<FoodModel>();
            quantityTypes = await ApiRequestService.GetList<QuantityTypeModel>();
        }

        protected string RecipeIngredientDisplay(RecipeIngredientModel recipeIngredientModel)
        {
            return foods.First(f => f.Id == recipeIngredientModel.FoodId).Name;
        }
    }
}
