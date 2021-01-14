using Core.Domain.Common;

namespace FoodApp.Core.Domain.Foods
{
    public class RecipeIngredient : BasePrivateEntity
    {
        public int FoodId { get; private set; }
        public Food Food { get; private set; }
        public int RecipeId { get; private set; }
        public Recipe Recipe { get; private set; }
        public decimal Amount { get; private set; }
        public QuantityType QuantityType { get; private set; }
        public RecipeIngredient()
        {

        }
    }
}
