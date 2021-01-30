using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Shared.Models.Recipes
{
    public class RecipeIngredientModel
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Value can not be negative")]
        public decimal Amount { get; set; }
        [Required]
        public string QuantityType { get; set; }
    }
}
