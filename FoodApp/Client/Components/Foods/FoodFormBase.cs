using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Foods
{
    public class FoodFormBase : ComponentBase
    {
        [Inject]
        public IApiRequestService ApiRequestService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public EventCallback<Food>? OnSave { get; set; }

        protected MudForm form;
        protected Food food = new();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }


        protected async Task SaveForm()
        {
            food = await ApiRequestService.PostJsonAsync<Food, Food>("/api/Foods/", food);
            if (OnSave != null)
            {
                await OnSave.Value.InvokeAsync(food);
            }
            form.Reset();
            Snackbar.Add($"{food.Name} successfully saved", Severity.Success);
            StateHasChanged();
        }
    }
}
