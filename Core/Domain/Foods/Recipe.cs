using Core.Domain.Common;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace FoodApp.Core.Domain.Foods
{

    public class Recipe : BasePrivateEntity
    {
        public string Name { get; private set; }
        public IReadOnlyList<RecipeIngredient> RecipeIngredients { get; private set; }

        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredient>().ToImmutableList();
        }

        private Recipe(string name, IEnumerable<RecipeIngredient> recipeIngredients) : this()
        {
            Name = name;
            RecipeIngredients = recipeIngredients.ToImmutableList();
        }

        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="recipeIngredients">The recipe ingredients.</param>
        /// <returns></returns>
        public static Recipe CreateNew(string name, IEnumerable<RecipeIngredient> recipeIngredients)
        {
            return new Recipe(name, recipeIngredients);
        }
        
    }
}
