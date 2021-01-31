using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Core.Common.Guards
{
    /// <summary>
    /// Guard Partial - IEnumerables
    /// </summary>
    public static partial class Guard
    {
        /// <summary>
        /// Guard to ensure a minimum length is met
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="minLength"></param>
        /// <param name="paramName"></param>
        /// <exception cref="ArgumentException">If items does not have at least a length of minLength</exception>
        /// <exception cref="ArgumentException">If items is null</exception>
        public static void HasMinimumLength<T>(IEnumerable<T> items, int minLength, string paramName)
        {
            if (items == null)
            {
                throw new ArgumentException($"{paramName} does not meet min length of {minLength}. Value is null");
            }
            var length = items.Count();
            if (length < minLength)
            {
                throw new ArgumentException($"{paramName} did not meet min length of {minLength}. Actual length is {length}");
            }
        }
    }
}
