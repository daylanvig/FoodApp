using FoodApp.Client.Services.System;
using FoodApp.Shared.Helpers;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Foods
{
    /// <summary>
    /// FoodForm - Component for adding/editing food
    /// </summary>
    public partial class FoodForm : ComponentBase
    {
        #region Dependencies
        [Inject]
        public IApiRequestService ApiRequestService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        #endregion
        #region Parameters
        [Parameter]
        public EventCallback OnFoodsChange { get; set; }
        [Parameter]
        public FoodModel Food { get; set; }
        #endregion
        #region Fields
        protected FoodModel food;
        protected MudForm form;
        #endregion
        #region Public Methods
        public void SetFood(FoodModel foodModel)
        {
            food = foodModel;
            StateHasChanged();
        }
        #endregion
        #region LifeCycle
        protected async override Task OnInitializedAsync()
        {
            food = Food;
            await base.OnInitializedAsync();
        }
        #endregion
        #region Helpers
        protected bool IsNew()
        {
            return EntityModelHelper.IsNew(food);
        }
        #endregion
        #region EventHandlers
        /// <summary>
        /// Clear the form
        /// </summary>
        protected void Clear()
        {
            food = new();
            form.Reset();
        }

        /// <summary>
        /// Delete an existing food
        /// </summary>
        /// <remarks>
        /// Deletes the food with the server and clears the form, notifying the parent.
        /// Fails if food is in use for any recipes
        /// </remarks>
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
                // Future - descriptive error logging/display
                Snackbar.Add("Failed to delete", Severity.Error);
                throw;
            }
        }

        /// <summary>
        /// Save the food to the server
        /// </summary>
        /// <remarks>
        /// If the food is a new food (id = 0), add is used. Else edit is used.
        /// On successful completion invokes <see cref="OnFoodsChange"/>
        /// </remarks>
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
                throw;
            }
        }

        #endregion
    }
}
