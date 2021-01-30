using Core.Domain.Common;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FoodApp.Core.Domain.Foods
{

    public class Recipe : BasePrivateEntity
    {
        public string Name { get; private set; }
        // backing field for ef
        private ICollection<RecipeIngredient> _recipeIngredients;
        public IReadOnlyList<RecipeIngredient> RecipeIngredients 
        { 
            get => _recipeIngredients.ToImmutableList(); 
            private set { _recipeIngredients = value.ToList(); } 
        }
        public string Url { get; private set; }

        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredient>().ToImmutableList();
        }

        private Recipe(string name, IEnumerable<RecipeIngredient> recipeIngredients, string url) : this()
        {
            Name = name;
            RecipeIngredients = recipeIngredients.ToImmutableList();
            Url = url;
        }

        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="recipeIngredients">The recipe ingredients.</param>
        /// <param name="url">Optional - URL where recipe can be found</param>
        /// <returns></returns>
        public static Recipe CreateNew(string name, IEnumerable<RecipeIngredient> recipeIngredients, string url)
        {
            return new Recipe(name, recipeIngredients, url);
        }

    }
}
