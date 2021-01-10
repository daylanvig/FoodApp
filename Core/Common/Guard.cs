using System;

namespace FoodApp.Core.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentException("Value is null.", paramName);
            }
        }
        public static void AgainstNullOrEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value is null or empty.", paramName);
            }
        }
    }
}
