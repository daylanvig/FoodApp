using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Core.Common.Guards
{
    public static partial class Guard
    {
        public static void HasMinimumLength<T>(IEnumerable<T> items, int minLength, string paramName)
        {
            var length = items.Count();
            if (length < minLength)
            {
                throw new ArgumentException($"{paramName} did not meet min length of {minLength}. Actual length is {length}");
            }
        }
    }
}
