using FoodApp.Core.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Core.Domain.QuantityTypes
{
    public class QuantityTypeInUseException : Exception
    {
        public QuantityTypeInUseException(IEnumerable<RecipeIngredient> recipeIngredients, IEnumerable<Food> foods) : base("QuantityType is in use")
        {
            if (recipeIngredients.Any())
            {
                Data.Add("Used in recipes", recipeIngredients.Select(r => r.Recipe.Name));
            }

            if (foods.Any())
            {
                Data.Add("Used in foods", foods.Select(f => f.Name));
            }
        }
    }
}
