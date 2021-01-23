using FoodApp.Shared.Models.Foods;
using System;
using System.Collections.Generic;

namespace FoodApp.Shared.AppProperties
{
    public class EntityControllerMap
    {
        /// <summary>
        /// Map of controller names to model types
        /// </summary>
        private static IDictionary<Type, string> _controllerMaps = new Dictionary<Type, string>
        {
            { typeof(FoodModel), "api/Foods" },
            { typeof(QuantityTypeModel), "api/QuantityTypes" },
            { typeof(RecipeModel), "api/Recipes" }
        };

        public static string GetController<TEntity>()
        {
            var isFound = _controllerMaps.TryGetValue(typeof(TEntity), out string controller);
            if (!isFound)
            {
                throw new ArgumentException("Invalid entity type");
            }

            return controller;
        }
    }
}
