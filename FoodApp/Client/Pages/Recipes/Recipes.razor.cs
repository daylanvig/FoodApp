using FoodApp.Client.Components.Shared;
using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Recipes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Pages.Recipes
{
    public partial class Recipes : ComponentBase
    {
        [Inject] IApiRequestService ApiRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected IReadOnlyList<RecipeModel> recipes;
        protected IEnumerable<TableHeader<RecipeModel>> tableHeaders;
        protected IEnumerable<TableTemplate<RecipeModel>> tableTemplates;
        protected IEnumerable<TableValue<RecipeModel>> tableValues;

        protected override async Task OnInitializedAsync()
        {
            recipes = await ApiRequestService.GetFromJsonAsync<IReadOnlyList<RecipeModel>>("/api/Recipes/");

            tableHeaders = new List<TableHeader<RecipeModel>>
            {
                new TableHeader<RecipeModel>
                {
                    Label = "Name",
                    SortBy = new Func<RecipeModel, string>(r => r.Name)
                }
            };

            tableTemplates = new List<TableTemplate<RecipeModel>>
            {
                new TableTemplate<RecipeModel>
                {
                    Label = "Name",
                    StringFormatter = t => t.Value.Name
                }
            };

            tableValues = recipes.Select(r => new TableValue<RecipeModel> { Value = r });
        }

        protected void ShowAddRecipe()
        {
            NavigationManager.NavigateTo("/Recipes/Add");
        }
    }
}
