using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Client.Pages.Foods
{
    public class InventoryBase : ComponentBase
    {
        [Inject]
        IApiRequestService ApiRequestService { get; set; }

        protected IReadOnlyList<FoodModel> foods;


        protected async Task LoadFoodData()
        {
            foods = await ApiRequestService.GetFromJsonAsync<IReadOnlyList<FoodModel>>("/api/Foods/");
        }


        protected async Task Update()
        {
            await LoadFoodData();
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadFoodData();
        }
    }
}
