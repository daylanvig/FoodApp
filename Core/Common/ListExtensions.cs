using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Core.Common
{
    public static class ListExtensions
    {
        /// <summary>
        /// Iterates over an ienumerable, with the index
        /// </summary>
        /// <remarks>
        /// Allow for use of foreach with index
        /// </remarks>
        /// <example>
        /// foreach(var (value, index) in array.WithIndex<>()){
        ///     Console.WriteLine(index, value);
        /// }
        /// </example>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static void ForEachWithIndex<TItem>(this List<TItem> items, Action<TItem, int> forEachItem)
        {
            for (var i = 0; i < items.Count; i++)
            {
                forEachItem(items[i], i);
            }
        }
    }
}
