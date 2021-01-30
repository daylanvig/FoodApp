using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Recipes;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Recipes
{
    public class Listing
    {
        public record Query() : IRequest<IEnumerable<RecipeModel>>;
        /// <summary>
        /// Get users foods
        /// </summary>
        public class Handler : IRequestHandler<Query, IEnumerable<RecipeModel>>
        {
            private readonly IRepository<Recipe> _recipeRepository;

            public Handler(IRepository<Recipe> recipeRepository)
            {
                _recipeRepository = recipeRepository;
            }

            public async Task<IEnumerable<RecipeModel>> Handle(Query request, CancellationToken cancellationToken = default)
            {
                var recipes = await _recipeRepository.ToListAsync(null, 
                    $"{nameof(Recipe.RecipeIngredients)}.{nameof(RecipeIngredient.QuantityType)}", 
                    $"{nameof(Recipe.RecipeIngredients)}.{nameof(RecipeIngredient.Food)}"
                );

                return recipes.Select(r => new RecipeModel
                {
                    Id = r.Id,
                    Ingredients = r.RecipeIngredients.Select(i => new RecipeIngredientModel
                    {
                        Amount = i.Amount,
                        FoodId = i.FoodId,
                        QuantityType = i.QuantityType.Type
                    }).ToList(),
                    Name = r.Name,
                    Url = r.Url
                });
            }
        }
    }
}
