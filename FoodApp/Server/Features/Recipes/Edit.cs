using AutoMapper;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using FoodApp.Shared.Models.Recipes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Recipes
{
    /// <summary>
    /// EditRecipe Feature
    /// </summary>
    public class Edit
    {
        /// <summary>
        /// EditRecipe Command
        /// </summary>
        public record Command(
            int Id, 
            string Name, 
            IEnumerable<RecipeIngredientModel> Ingredients, 
            string Url, 
            IEnumerable<RecipeStepModel> Steps
        ) : IRequest<RecipeModel>;

        public class Handler : IRequestHandler<Command, RecipeModel>
        {
            private readonly IRepository<Recipe> _recipeRepository;
            private readonly IQuantityTypeService _quantityTypeService;
            private readonly IMapper _mapper;

            public Handler(
                IRepository<Recipe> recipeRepository,
                IQuantityTypeService quantityTypeService,
                IMapper mapper)
            {
                _recipeRepository = recipeRepository;
                _quantityTypeService = quantityTypeService;
                _mapper = mapper;
            }

            public async Task<RecipeModel> Handle(Command request, CancellationToken cancellationToken)
            {
                Guard.AgainstNull(request, nameof(request));

                var recipe = await _recipeRepository.GetByIdAsync(
                                                request.Id,
                                                $"{nameof(Recipe.RecipeIngredients)}.{nameof(RecipeIngredient.Food)}",
                                                nameof(Recipe.RecipeSteps)
                                            );

                Guard.AgainstNull(recipe, nameof(Command.Id), "Recipe not found");
                var quantityTypes = await _quantityTypeService.EnsureCreatedAsync(request.Ingredients.Select(q => q.QuantityType));
                IEnumerable<RecipeIngredient> recipeIngredients = Utilities.CreateIngredients(quantityTypes, request.Ingredients, request.Id);

                recipe.UpdateName(request.Name);
                recipe.UpdateUrl(request.Url);
                recipe.UpdateIngredients(recipeIngredients);
                await _recipeRepository.EditAsync(recipe);
                return _mapper.Map<RecipeModel>(recipe);
            }
        }
    }
}
