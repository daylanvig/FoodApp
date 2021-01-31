using FoodApp.Client.Components.QuantityTypes;
using FoodApp.Client.Components.Shared;
using FoodApp.Client.Services.System;
using FoodApp.Shared.Models.Foods;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Pages.QuantityTypes
{
    /// <summary>
    /// QuantityTypes Page
    /// </summary>
    public partial class QuantityTypes : ComponentBase
    {
        #region Dependencies
        [Inject] IApiRequestService ApiRequestService { get; set; }
        #endregion
        #region Fields
        private IEnumerable<TableHeader<QuantityTypeModel>> _tableHeaders;
        private IEnumerable<TableTemplate<QuantityTypeModel>> _tableTemplates;
        private IEnumerable<TableValue<QuantityTypeModel>> _tableValues;
        private QuantityTypeForm _form;
        #endregion
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await LoadData();
        }

        private async Task LoadData()
        {
            var quantityTypes = await ApiRequestService.GetList<QuantityTypeModel>();

            _tableHeaders = new TableHeader<QuantityTypeModel>[]
            {
                new("Label", qt => qt.Type)
            };

            _tableTemplates = new TableTemplate<QuantityTypeModel>[]
            {
                new("Label", qt => qt.Value.Type.ToString())
            };
            _tableValues = quantityTypes.Select(q => new TableValue<QuantityTypeModel>(q));
        }

        private async Task Update()
        {
            await LoadData();
        }
        private void SetQuantityType(QuantityTypeModel quantityType)
        {
            _form.SetQuantityType(quantityType);
        }
    }
}
