using System;
using System.Collections.Generic;
using System.Text;

namespace FoodApp.Core.Common.Guards
{
    /// <summary>
    /// NullGuards Partial
    /// </summary>
    public static partial class Guard
    {
        /// <summary>
        /// Check that value is not null
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">If value is null</exception>
        public static void AgainstNull(object value, string paramName, string message = "Value is null")
        {
            if (value == null)
            {
                throw new ArgumentException(message, paramName);
            }
        }

        /// <summary>
        /// Check to ensure value is null
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentException">If value is not null</exception>
        public static void ShouldBeNull(object value, string paramName, string message = "Value is not null")
        {
            if (value != null)
            {
                throw new ArgumentException(message, paramName);
            }
        }

    }
}
