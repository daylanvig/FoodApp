using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Recipes
{
    public class RecipeFormBase : ComponentBase
    {
        [Inject]
        IApiRequestService ApiRequestService { get; set; }
        protected IReadOnlyList<FoodModel> foods;
        protected IReadOnlyList<QuantityTypeModel> quantityTypes;

        protected RecipeModel recipe = new()
        {
            Ingredients = new()
        };

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            
        }
    }
}
