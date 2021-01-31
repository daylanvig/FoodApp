using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FoodApp.Client.Components.Shared
{
    public partial class Table<TEntity> : ComponentBase
    {
        protected List<TableValue<TEntity>> tableValues;
        [Parameter]
        public IEnumerable<TableHeader<TEntity>> TableHeaders { get; set; }
        [Parameter]
        public IEnumerable<TableTemplate<TEntity>> TableTemplates { get; set; }
        [Parameter]
        public IEnumerable<TableValue<TEntity>> TableValues { 
            get => tableValues; 
            set { 
                tableValues = value.ToList(); 
            }
        }

    }

    public class TableHeader<TSortProp>
    {
        public string Label { get; set; }
        public Func<TSortProp, object> SortBy { get; set; }
    }

    public class TableTemplate<TEntity>
    {
        public string Label { get; set; }
        public Func<TableValue<TEntity>, string> StringFormatter { get; set; }   
    }

    /// <summary>
    /// TableValue - Value of one item in table (/row)
    /// </summary>
    public class TableValue<TProp>
    {
        public TProp Value { get; set; }
    }
}
