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
        public EventCallback OnSave { get; set; }

        protected MudForm form;
        protected FoodModel food = new();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }


        protected async Task SaveForm()
        {
            var foodName = food.Name;
            food = await ApiRequestService.PostJsonAsync<FoodModel, FoodModel>("/api/Foods/", food);
            Snackbar.Add($"\"{foodName}\" successfully saved!", Severity.Success);
            form.Reset();
            await OnSave.InvokeAsync();
        }
    }
}
