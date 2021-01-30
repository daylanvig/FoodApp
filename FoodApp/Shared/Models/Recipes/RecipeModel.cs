using FoodApp.Shared.Models.Foods;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Shared.Models.Recipes
{
    public class RecipeModel : IEntityModel
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        public List<RecipeIngredientModel> Ingredients { get; set; } = new();
        [DataType(DataType.Url)] // optional
        public string Url { get; set; }
        public List<RecipeStepModel> Steps { get; set; } = new();
    }
}
