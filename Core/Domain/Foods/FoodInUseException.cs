using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Core.Domain.Foods
{
    /// <summary>
    /// FoodInUseException - Food that is used in recipes can not be deleted
    /// </summary>
    public class FoodInUseException : Exception
    {
        public FoodInUseException(IEnumerable<RecipeIngredient> recipeIngredients) : base("Food is in use")
        {
            if (recipeIngredients.Any())
            {
                Data.Add("Used in recipes", string.Join(", ", recipeIngredients.Select(r => r.Recipe.Name)));
            }
        }

        public override string ToString()
        {
            return $"{Message} - {Data["Used in recipes"]}";
        }
    }
}
