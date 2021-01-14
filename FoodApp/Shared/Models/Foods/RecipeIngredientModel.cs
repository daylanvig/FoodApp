using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Shared.Models.Foods
{
    public class RecipeIngredientModel
    {
        public int FoodId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Value can not be negative")]
        public decimal Amount { get; set; }
        [Required]
        public string QuantityType { get; set; }
    }
}
