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

        protected IReadOnlyList<Food> foods = new List<Food>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            foods = await ApiRequestService.GetFromJsonAsync<IReadOnlyList<Food>>("/api/Foods/");
        }
    }
}
