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

        }

        private Recipe(string name, IEnumerable<RecipeIngredient> recipeIngredients) : this()
        {
            Name = name;
            RecipeIngredients = recipeIngredients.ToImmutableList();
        }

        public static Recipe CreateRecipe(string name, IEnumerable<RecipeIngredient> recipeIngredients)
        {
            return new Recipe(name, recipeIngredients);
        }
        
    }
}
