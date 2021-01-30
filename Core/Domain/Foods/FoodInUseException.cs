using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodApp.Core.Domain.Foods
{
    public class FoodInUseException : Exception
    {
        public FoodInUseException(IEnumerable<RecipeIngredient> recipeIngredients) : base("Food is in use")
        {
            if (recipeIngredients.Any())
            {
                Data.Add("Used in recipes", recipeIngredients.Select(r => r.Recipe.Name));
            }
        }
    }
}
