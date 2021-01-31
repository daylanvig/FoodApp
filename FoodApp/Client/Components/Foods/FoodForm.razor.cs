using FoodApp.Client.Extensions;
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
        private FoodModel _food;
        #endregion
        #region Public Methods
        public void SetFood(FoodModel foodModel)
        {
            _food = foodModel;
            StateHasChanged();
        }
        #endregion
        #region LifeCycle
        protected async override Task OnInitializedAsync()
        {
            _food = Food;
            await base.OnInitializedAsync();
        }
        #endregion
        #region Helpers
        protected bool IsNew => EntityModelHelper.IsNew(_food);
        #endregion
        #region EventHandlers
        /// <summary>
        /// Clear the form
        /// </summary>
        private void Clear()
        {
            _food = new();
        }

        /// <summary>
        /// Delete an existing food
        /// </summary>
        /// <remarks>
        /// Deletes the food with the server and clears the form, notifying the parent.
        /// Fails if food is in use for any recipes
        /// </remarks>
        private async Task DeleteFood()
        {
            try
            {
                await ApiRequestService.Delete<FoodModel>(_food.Id);
                Snackbar.ShowDeleteSuccess(_food.Name);
                Clear();
                await OnFoodsChange.InvokeAsync();
            }
            catch
            {
                // Future - descriptive error logging/display
                Snackbar.ShowDeleteFailed();
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
        private async Task SaveFood()
        {
            var foodName = _food.Name;
            try
            {
                if (_food.Id == 0)
                {
                    _food = await ApiRequestService.Add(_food);
                }
                else
                {
                    _food = await ApiRequestService.Edit(_food.Id, _food);
                }
                Snackbar.ShowSaveSuccess(foodName);
                Clear();
                await OnFoodsChange.InvokeAsync();
            }
            catch
            {
                Snackbar.ShowSaveFailed();
                throw;
            }
        }

        #endregion
    }
}
