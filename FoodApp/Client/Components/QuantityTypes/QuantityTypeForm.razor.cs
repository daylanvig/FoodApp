using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
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

        private IReadOnlyList<QuantityTypeModel> _quantityTypes;

        #region LifeCycle
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            
        }
        #endregion


        #region EventHandlers
        private void Clear()
        {

        }

        private async Task Delete()
        {

        }

        private async Task Save()
        {

        }
        #endregion
    }
}
