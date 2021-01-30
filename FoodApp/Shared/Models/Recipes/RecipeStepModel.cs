using System.ComponentModel.DataAnnotations;

namespace FoodApp.Shared.Models.Recipes
{
    /// <summary>
    /// RecipeStepModel - A step in a recipe
    /// </summary>
    public class RecipeStepModel
    {
        [Range(1, int.MaxValue)]
        public int StepNumber { get; set; }
        [Required]
        public string Direction { get; set; }
    }
}
