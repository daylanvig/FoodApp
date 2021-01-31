using System;

namespace FoodApp.Core.Common.Guards
{
    /// <summary>
    /// StringGuard Methods
    /// </summary>
    public static partial class Guard
    {
        /// <summary>
        /// Againsts the value beingg null or empty
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <exception cref="ArgumentException">Value is null or empty.</exception>
        public static void AgainstNullOrEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value is null or empty.", paramName);
            }
        }
    }
}
