using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Pages.Foods
{
    public class RecipesBase : ComponentBase
    {
        [Inject] IApiRequestService ApiRequestService { get; set; }
        protected IReadOnlyList<RecipeModel> recipes;

       

        protected override async Task OnInitializedAsync()
        {
            recipes = await ApiRequestService.GetFromJsonAsync<IReadOnlyList<RecipeModel>>("/api/Recipes/");
        }

        protected void ShowAddRecipe()
        {
            // todo
            throw new NotImplementedException();
        }
    }
}
