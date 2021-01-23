using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Shared.Models.Foods
{
    public class FoodModel
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Value can not be negative")]
        [Required]
        public decimal? AmountOnHand { get; set; }
        [Required]
        public string QuantityType { get; set; }
    }
}
