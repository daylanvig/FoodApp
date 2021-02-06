using System.Collections.Generic;

namespace FoodApp.Core.Domain.QuantityTypes
{
    public class CommonQuantityTypes
    {
        // future -> weight, volume, conversions, etc
        /// <summary>
        /// All commonly used quantity types
        /// </summary>
        public static readonly IReadOnlyCollection<string> All = new string[]
        {
            "tbsp",
            "tbsps",
            "tsp",
            "tsps",
            "teaspoons",
            "tablespoons",
            "cups",
            "cup",
            "oz",
            "lb"
        };
    }
}
