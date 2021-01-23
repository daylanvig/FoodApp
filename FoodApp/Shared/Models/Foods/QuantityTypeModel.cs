using System.ComponentModel.DataAnnotations;

namespace FoodApp.Shared.Models.Foods
{
    public class QuantityTypeModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(10)]
        public string Type { get; set; }
    }
}
