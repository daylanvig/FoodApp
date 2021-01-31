using FoodApp.Client.Extensions;
using FoodApp.Client.Services.System;
using FoodApp.Shared.Helpers;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.QuantityTypes
{
    public partial class QuantityTypeForm : ComponentBase
    {
        #region Dependencies
        [Inject]
        public IApiRequestService ApiRequestService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
        #endregion
        #region Parameters
        [Parameter]
        public QuantityTypeModel QuantityType { get; set; }
        [Parameter]
        public EventCallback OnQuantityTypesChange { get; set; }
        #endregion
        #region Fields
        private QuantityTypeModel _quantityType = new();
        #endregion
        #region Helpers
        private bool IsNew => EntityModelHelper.IsNew(_quantityType);

        #endregion
        #region Public Methods
        /// <summary>
        /// Set quantity type being edited
        /// </summary>
        /// <param name="quantityType"></param>
        public void SetQuantityType(QuantityTypeModel quantityType)
        {
            _quantityType = quantityType;
            StateHasChanged();
        }
        #endregion
        #region EventHandlers
        private void Clear()
        {
            _quantityType = new();
        }

        /// <summary>
        /// Delete QT 
        /// </summary>
        private async Task Delete()
        {
            try
            {
                await ApiRequestService.Delete<QuantityTypeModel>(_quantityType.Id);
                Snackbar.ShowDeleteSuccess(_quantityType.Type);
                Clear();
                await OnQuantityTypesChange.InvokeAsync();
            }
            catch
            {
                Snackbar.ShowDeleteFailed();
            }
        }

        /// <summary>
        /// Save QT being edited to server
        /// </summary>
        private async Task Save()
        {
            try
            {
                if (IsNew)
                {
                    await ApiRequestService.Add(_quantityType);

                }
                else
                {
                    await ApiRequestService.Edit(_quantityType.Id, _quantityType);
                }
                Snackbar.ShowSaveSuccess(_quantityType.Type);
                Clear();
                await OnQuantityTypesChange.InvokeAsync();
            }
            catch
            {
                Snackbar.ShowSaveFailed();
            }
        }
        #endregion
    }
}
