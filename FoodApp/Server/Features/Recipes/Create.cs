using FluentValidation;
using FoodApp.Core.Common;
using FoodApp.Core.Domain.Foods;
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
    public class Create
    {
        public record Command(string Name, IEnumerable<RecipeIngredientModel> Ingredients, string Url) : IRequest<RecipeModel>;

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

        public class Handler : IRequestHandler<Command, RecipeModel>
        {
            private readonly IRepository<Recipe> _recipeRepository;
            private readonly IQuantityTypeService _quantityTypeService;
            private readonly IRecipeIngredientService _recipeIngredientService;

            public Handler(
                IRepository<Recipe> recipeRepository,
                IQuantityTypeService quantityTypeService,
                IRecipeIngredientService recipeIngredientService)
            {
                _recipeRepository = recipeRepository;
                _quantityTypeService = quantityTypeService;
                _recipeIngredientService = recipeIngredientService;
            }

            public async Task<RecipeModel> Handle(Command request, CancellationToken cancellationToken = default)
            {
                // no duplicate recipe names
                if ((await _recipeRepository.FindAsync(r => r.Name == request.Name)) != null)
                {
                    throw new ArgumentException("Recipe name in use", nameof(Command.Name));
                }

                // Ensure all quantity types are created
                var quantityTypes = await _quantityTypeService.EnsureCreatedAsync(request.Ingredients.Select(i => i.QuantityType));

                // Build list of ingredients
                List<RecipeIngredient> recipeIngredients = new(request.Ingredients.Count());
                foreach (var recipeIngredient in request.Ingredients)
                {
                    var quantityType = quantityTypes.Single(q => q.Type == recipeIngredient.QuantityType);
                    recipeIngredients.Add(RecipeIngredient.CreateNew(recipeIngredient.FoodId, 0, recipeIngredient.Amount, quantityType.Id));
                }

                var recipe = Recipe.CreateNew(request.Name, recipeIngredients, request.Url);
                await _recipeRepository.AddAsync(recipe);

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
