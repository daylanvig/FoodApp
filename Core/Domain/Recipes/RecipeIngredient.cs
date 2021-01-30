using Core.Domain.Common;
using FoodApp.Core.Domain.QuantityTypes;

namespace FoodApp.Core.Domain.Foods
{
    public class RecipeIngredient : BasePrivateEntity
    {
        public int FoodId { get; private set; }
        public Food Food { get; private set; }
        public int RecipeId { get; private set; }
        public Recipe Recipe { get; private set; }
        public decimal Amount { get; private set; }
        public int QuantityTypeId { get; private set; }
        public QuantityType QuantityType { get; private set; }
        public RecipeIngredient()
        {

        }

        private RecipeIngredient(int foodId, int recipeId, decimal amount, int quantityTypeId) : this()
        {
            FoodId = foodId;
            RecipeId = recipeId;
            Amount = amount;
            QuantityTypeId = quantityTypeId;
        }

        /// <summary>
        /// Creates the new recipe ingredient
        /// </summary>
        /// <param name="foodId">The food identifier.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <param name="amount">The amount used in the recipe.</param>
        /// <param name="quantityTypeId">The quantity type identifier.</param>
        /// <returns></returns>
        public static RecipeIngredient CreateNew(int foodId, int recipeId, decimal amount, int quantityTypeId)
        {
            return new RecipeIngredient(foodId, recipeId, amount, quantityTypeId);
        }

        /// <summary>
        /// Tries to update the properties.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="quantityTypeId">The quantity type identifier.</param>
        /// <returns>Try if values have changed.</returns>
        public bool TryUpdate(decimal amount, int quantityTypeId)
        {
            if (Amount == amount && QuantityTypeId == quantityTypeId)
            {
                return false;
            }

            IsCreated();
            Amount = amount;
            QuantityTypeId = quantityTypeId;
            return true;
        }

    }
}
