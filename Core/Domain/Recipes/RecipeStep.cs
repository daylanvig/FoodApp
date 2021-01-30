using Core.Domain.Common;

namespace FoodApp.Core.Domain.Recipes
{
    public class RecipeStep : BasePrivateEntity
    {
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string Direction { get; set; }

        private RecipeStep(int stepNumber, string direction)
        {
            StepNumber = stepNumber;
            Direction = direction;
        }

        /// <summary>
        /// Create new recipe step
        /// </summary>
        /// <param name="stepNumber"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static RecipeStep CreateNew(int stepNumber, string direction)
        {
            return new RecipeStep(stepNumber, direction);
        }
    }
}
