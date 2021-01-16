using FoodApp.Core.Domain.Foods;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Services.Recipes
{
    public interface IRecipeIngredientService
    {
        Task<RecipeIngredient> EnsureCreatedAsync(int foodId, int recipeId, decimal amount, int quantityTypeId);
    }
}