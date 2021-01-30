using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Recipes;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Client.Pages.Recipes
{
    public partial class Recipes : ComponentBase
    {
        [Inject] IApiRequestService ApiRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected IReadOnlyList<RecipeModel> recipes;

       

        protected override async Task OnInitializedAsync()
        {
            recipes = await ApiRequestService.GetFromJsonAsync<IReadOnlyList<RecipeModel>>("/api/Recipes/");
        }

        protected void ShowAddRecipe()
        {
            NavigationManager.NavigateTo("/Recipes/Add");
        }
    }
}
