using FoodApp.Client.Services.System;
using FoodApp.Shared.Helpers;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Foods
{
    public partial class FoodForm : ComponentBase
    {
        [Inject]
        public IApiRequestService ApiRequestService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Parameter]
        public EventCallback OnFoodsChange { get; set; }

        protected FoodModel food;
        [Parameter]
        public FoodModel Food { get; set; }
        protected MudForm form;

        protected async override Task OnInitializedAsync()
        {
            food = Food;
            await base.OnInitializedAsync();
        }

        public void SetFood(FoodModel foodModel)
        {
            food = foodModel;
            StateHasChanged();
        }

        protected bool IsNew()
        {
            return EntityModelHelper.IsNew(food);
        }

        protected void Clear()
        {
            food = new();
            form.Reset();
        }

        protected async Task DeleteFood()
        {
            try
            {
                await ApiRequestService.Delete<FoodModel>(food.Id);
                Snackbar.Add($"Food successfully deleted!", Severity.Normal);
                Clear();
                await OnFoodsChange.InvokeAsync();
            }
            catch
            {
                Snackbar.Add("Failed to delete", Severity.Error);
            }
        }

        protected async Task SaveFood()
        {
            var foodName = food.Name;
            try
            {
                if (food.Id == 0)
                {
                    food = await ApiRequestService.Add(food);
                }
                else
                {
                    food = await ApiRequestService.Edit(food.Id, food);
                }
                
                Snackbar.Add($"\"{foodName}\" successfully saved!", Severity.Success);
                Clear();
                await OnFoodsChange.InvokeAsync();
            }
            catch
            {
                Snackbar.Add("Failed to save", Severity.Error);
            }
        }
    }
}
