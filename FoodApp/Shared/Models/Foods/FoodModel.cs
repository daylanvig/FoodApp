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
        public string QuanityType { get; }
        [Required]
        public string QuantityType { get; set; }
        public FoodModel(int id = 0, string name = null, decimal? amountOnHand = null, string quanityType = null)
        {
            Id = id;
            Name = name;
            AmountOnHand = amountOnHand;
            QuanityType = quanityType;
        }
    }
}
