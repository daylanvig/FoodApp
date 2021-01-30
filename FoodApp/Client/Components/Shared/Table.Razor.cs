using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Components.Shared
{
    public partial class Table<TEntity, TSortProp> : ComponentBase
    {
        [Parameter]
        public IEnumerable<TableHeader<TSortProp>> TableHeaders { get; set; }
        [Parameter]
        public IEnumerable<TableTemplate<TEntity>> TableTemplates { get; set; }
        [Parameter]
        public IEnumerable<TableEntry<TEntity>> TableValues { get; set; }

    }

    /// <summary>
    /// TableEntry - One Entry/Row in a table
    /// </summary>
    public class TableEntry<TEntity>
    {
        public IEnumerable<TableValue<TEntity>> TableValues { get; set; }

    }

    public class TableHeader<TSortProp>
    {
        public string Label { get; set; }
        public Func<TSortProp, object> SortBy { get; set; }
    }

    public class TableTemplate<TEntity>
    {
        public string Label { get; set; }
        public Func<TableEntry<TEntity>, string> StringFormatter { get; set; }

        
    }

    /// <summary>
    /// TableValue - Value of one cell (within a row) in a table
    /// </summary>
    public class TableValue<TProp>
    {
        
        public TProp Value { get; set; }
    }
}
