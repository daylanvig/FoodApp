using FluentValidation;
using FoodApp.Core.Common;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Domain.Recipes;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using FoodApp.Services.Recipes;
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
    /// Create Recipe Feature
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Create Recipe Command
        /// </summary>
        public record Command(string Name, IEnumerable<RecipeIngredientModel> Ingredients, string Url, IEnumerable<RecipeStepModel> Steps) : IRequest<RecipeModel>;

        /// <summary>
        /// Create Recipe Command Validator
        /// </summary>
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(c => c.Name)
                    .NotEmpty()
                    .MaximumLength(150);

                RuleFor(c => c.Ingredients)
                    .NotEmpty();
            }
        }

        /// <summary>
        /// Create Recipe Handler
        /// </summary>
        public class Handler : IRequestHandler<Command, RecipeModel>
        {
            private readonly IRepository<Recipe> _recipeRepository;
            private readonly IQuantityTypeService _quantityTypeService;

            public Handler(
                IRepository<Recipe> recipeRepository,
                IQuantityTypeService quantityTypeService)
            {
                _recipeRepository = recipeRepository;
                _quantityTypeService = quantityTypeService;
            }

            /// <summary>
            /// Handle Creating a Recipe
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <exception cref="ArgumentException">If recipe name is in use</exception>
            /// <returns></returns>
            public async Task<RecipeModel> Handle(Command request, CancellationToken cancellationToken = default)
            {
                // no duplicate recipe names
                Guard.ShouldBeNull(await _recipeRepository.FindAsync(r => r.Name == request.Name), nameof(Command.Name), "Recipe name is in use");
                // Ensure all quantity types are created
                var quantityTypes = await _quantityTypeService.EnsureCreatedAsync(request.Ingredients.Select(i => i.QuantityType));

                // Build list of ingredients
                IEnumerable<RecipeIngredient> recipeIngredients = Utilities.CreateIngredients(quantityTypes, request.Ingredients, 0);
                var steps = request.Steps.Select(s => RecipeStep.CreateNew(s.StepNumber, s.Direction));
                
                var recipe = Recipe.CreateNew(request.Name, recipeIngredients, request.Url, steps);
                await _recipeRepository.AddAsync(recipe);
                // todo -> add a mapping profile for this
                return new RecipeModel
                {
                    Id = recipe.Id,
                    Ingredients = recipe.RecipeIngredients.Select(r => new RecipeIngredientModel
                    {
                        Amount = r.Amount,
                        FoodId = r.FoodId,
                        QuantityType = quantityTypes.Single(q => q.Id == r.QuantityTypeId).Type
                    }).ToList(),
                    Name = recipe.Name,
                    Url = recipe.Url
                };
            }
        }
    }
}
