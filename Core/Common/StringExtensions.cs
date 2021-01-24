using System;

namespace FoodApp.Core.Common
{
    public static class StringExtensions
    {
        public static bool ContainsInsensitive(this string stringA, string stringB)
        {
            return stringA.Contains(stringB, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
