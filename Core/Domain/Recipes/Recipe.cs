using Core.Domain.Common;
using FoodApp.Core.Domain.Recipes;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FoodApp.Core.Domain.Foods
{

    public class Recipe : BasePrivateEntity
    {
        public string Name { get; private set; }
        public string Url { get; private set; }

        #region BackingFields
        /// <summary>
        /// The recipe ingredients
        /// </summary>
        /// <remarks>
        /// Backing field for ef for <see cref="RecipeIngredients"/>
        /// </remarks>
        private List<RecipeIngredient> _recipeIngredients;
        /// <summary>
        /// The recipe steps
        /// </summary>
        /// <remarks>
        /// Backing field for EF for <see cref="RecipeSteps"/>
        /// </remarks>
        private List<RecipeStep> _recipeSteps;

        #endregion

        #region OneToManyRelations
        /// <summary>
        /// Gets the recipe ingredients.
        /// </summary>
        /// <value>
        /// The recipe ingredients.
        /// </value>
        /// <seealso cref="_recipeIngredients"/>
        public IReadOnlyList<RecipeIngredient> RecipeIngredients
        {
            get => _recipeIngredients.ToImmutableList();
            private set { _recipeIngredients = value.ToList(); }
        }

        /// <summary>
        /// Gets the recipe steps.
        /// </summary>
        /// <value>
        /// The recipe steps.
        /// </value>
        /// <seealso cref="_recipeSteps"/>
        public IReadOnlyList<RecipeStep> RecipeSteps
        {
            get => _recipeSteps.ToImmutableList();
            private set
            {
                _recipeSteps = value.ToList();
            }
        }
        #endregion

        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredient>();
            RecipeSteps = new List<RecipeStep>();
        }

        private Recipe(string name, IEnumerable<RecipeIngredient> recipeIngredients, string url, IEnumerable<RecipeStep> steps) : this()
        {
            Name = name;
            RecipeIngredients = recipeIngredients.ToImmutableList();
            Url = url;
            RecipeSteps = steps.ToImmutableList();
        }

        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="recipeIngredients">The recipe ingredients.</param>
        /// <param name="url">Optional - URL where recipe can be found</param>
        /// <returns></returns>
        public static Recipe CreateNew(string name, IEnumerable<RecipeIngredient> recipeIngredients, string url, IEnumerable<RecipeStep> steps)
        {
            return new Recipe(name, recipeIngredients, url, steps);
        }

    }
}
