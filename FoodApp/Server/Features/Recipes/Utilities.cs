using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Shared.Models.Recipes;
using System.Collections.Generic;
using System.Linq;

namespace FoodApp.Server.Features.Recipes
{
    /// <summary>
    /// Recipe Utilities
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Create recipe ingredient pairs from recipe ingredient model
        /// </summary>
        /// <param name="quantityTypes"></param>
        /// <param name="ingredients"></param>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        public static IEnumerable<RecipeIngredient> CreateIngredients(IEnumerable<QuantityType> quantityTypes, IEnumerable<RecipeIngredientModel> ingredients, int recipeId)
        {
            List<RecipeIngredient> recipeIngredients = new(ingredients.Count());
            foreach (var recipeIngredient in ingredients)
            {
                var quantityType = quantityTypes.Single(q => q.Type == recipeIngredient.QuantityType);
                recipeIngredients.Add(RecipeIngredient.CreateNew(recipeIngredient.FoodId, recipeId, recipeIngredient.Amount, quantityType.Id));
            }
            return recipeIngredients;
        }
    }
}
