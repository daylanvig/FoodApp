using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Shared.Models.Foods
{
    public class RecipeModel
    {
        public int Id { get; set; }
        [Required, StringLength(150)]
        public string Name { get; set; }
        public List<RecipeIngredientModel> Ingredients { get; set; } = new List<RecipeIngredientModel>();
        [DataType(DataType.Url)] // optional
        public string Url { get; set; }
    }
}
