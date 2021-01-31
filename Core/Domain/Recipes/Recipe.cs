using Core.Domain.Common;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Recipes;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FoodApp.Core.Domain.Foods
{
    /// <summary>
    /// Entity Representing a Recipe
    /// </summary>
    /// <remarks>
    /// Recipes are made up of one or more ingredients, with one or more directions
    /// </remarks>
    public class Recipe : BasePrivateEntity
    {
        #region Properties
        public string Name { get; private set; }
        public string Url { get; private set; }
        #endregion
        #region Properties - OneToManyRelations
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

        #region Constructors
        /// <summary>
        /// Ctor - Required By EF
        /// </summary>
        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredient>();
            RecipeSteps = new List<RecipeStep>();
        }
        /// <summary>
        /// Ctor - Creating a new recipe
        /// </summary>
        /// <param name="name"></param>
        /// <param name="recipeIngredients"></param>
        /// <param name="url"></param>
        /// <param name="steps"></param>
        private Recipe(string name, IEnumerable<RecipeIngredient> recipeIngredients, string url, IEnumerable<RecipeStep> steps) : this()
        {
            Name = name;
            RecipeIngredients = recipeIngredients.ToImmutableList();
            Url = url;
            RecipeSteps = steps.ToImmutableList();
        }
        #endregion
        #region Static Methods
        /// <summary>
        /// Creates new instance
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="recipeIngredients">The recipe ingredients.</param>
        /// <param name="url">Optional - URL where recipe can be found</param>
        /// <exception cref="System.ArgumentException">If name is null or empty</exception>
        /// <exception cref="System.ArgumentException">If recipeIngredients has a length of 0</exception>
        /// <exception cref="System.ArgumentException">If steps has a length of 0</exception>
        /// <returns></returns>
        public static Recipe CreateNew(string name, IEnumerable<RecipeIngredient> recipeIngredients, string url, IEnumerable<RecipeStep> steps)
        {
            Guard.AgainstNullOrEmpty(name, nameof(Name));
            Guard.HasMinimumLength(recipeIngredients, 1, Guard.GetFullPropertyIdentifier<Recipe>(nameof(RecipeIngredients)));
            Guard.HasMinimumLength(steps, 1, Guard.GetFullPropertyIdentifier<Recipe>(nameof(RecipeSteps)));
            return new Recipe(name, recipeIngredients, url, steps);
        }
        #endregion

    }
}
