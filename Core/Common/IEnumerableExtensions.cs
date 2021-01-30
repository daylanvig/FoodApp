using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Core.Common
{
    public static class IEnumerableExtensions
    {
        public static TValue MaxOrDefault<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> condition, TValue defaultValue = default)
        {
            if (!items.Any())
            {
                return defaultValue;
            }
            return items.Max(condition);
        }

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
        public static IEnumerable<(TItem, int index)> WithIndex<TItem>(this IEnumerable<TItem> items)
        {
            return items.Select((item, index) => (item, index));
        }
    }
}
