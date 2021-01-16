using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using System.Threading.Tasks;

namespace FoodApp.Services.Recipes
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRepository<RecipeIngredient> _recipeIngredientRepository;

        public RecipeIngredientService(IRepository<RecipeIngredient> recipeIngredientRepository)
        {
            _recipeIngredientRepository = recipeIngredientRepository;
        }

        public async Task<RecipeIngredient> EnsureCreatedAsync(int foodId, int recipeId, decimal amount, int quantityTypeId)
        {
            RecipeIngredient recipeIngredient = await _recipeIngredientRepository.FindAsync(r => r.FoodId == foodId && r.RecipeId == recipeId);
            if (recipeIngredient == null)
            {
                recipeIngredient = RecipeIngredient.CreateNew(foodId, recipeId, amount, quantityTypeId);
                await _recipeIngredientRepository.AddAsync(recipeIngredient);
            }
            else if (recipeIngredient.TryUpdate(amount, quantityTypeId))
            {
                await _recipeIngredientRepository.EditAsync(recipeIngredient);
            }
            return recipeIngredient;
        }
    }
}
