using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Shared.Models.Foods
{
    public class Food
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Value can not be negative")]
        [Required]
        public decimal? AmountOnHand { get; set; }
        public string QuantityType { get; set; }
    }
}
