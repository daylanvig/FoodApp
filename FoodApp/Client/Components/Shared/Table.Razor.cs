using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Client.Components.Shared
{
    // todo -> sorting not working
    /// <summary>
    /// Table Component
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial class Table<TEntity> : ComponentBase
    {
        protected List<TableValue<TEntity>> tableValues;
        #region Parameters
        [Parameter]
        public IEnumerable<TableHeader<TEntity>> TableHeaders { get; set; }
        [Parameter]
        public IEnumerable<TableTemplate<TEntity>> TableTemplates { get; set; }
        [Parameter]
        public IEnumerable<TableValue<TEntity>> TableValues
        {
            get => tableValues;
            set
            {
                tableValues = value.ToList();
            }
        }
        [Parameter]
        public EventCallback<TEntity> OnClick { get; set; }
        #endregion
        #region EventHandlers
        private async void OnRowClick(TableRowClickEventArgs<TableValue<TEntity>> e)
        {
             await OnClick.InvokeAsync(e.Item.Value);
        }
        #endregion
    }

    public record TableHeader<TEntity>(string Label, Func<TEntity, object> SortBy);
    public record TableTemplate<TEntity>(string Label, Func<TableValue<TEntity>, string> StringFormatter);
    public record TableValue<TEntity>(TEntity Value);
}
