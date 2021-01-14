using System;

namespace FoodApp.Core.Common
{
    public static class Guard
    {
        public static void AgainstNull(object value, string paramName, string message = "Value is null")
        {
            if (value == null)
            {
                throw new ArgumentException(message, paramName);
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
