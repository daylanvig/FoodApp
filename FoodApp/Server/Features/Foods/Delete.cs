﻿using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    /// <summary>
    /// Delete Food Feature
    /// </summary>
    public class Delete
    {
        /// <summary>
        /// DeleteFoodCommand
        /// </summary>
        public record Command(int Id) : IRequest;

        /// <summary>
        /// Handler for deleting food
        /// </summary>
        public class Handler : IRequestHandler<Command>
        {
            private readonly IRepository<Food> _foodRepository;
            private readonly IRepository<RecipeIngredient> _recipeIngredientRepository;

            public Handler(IRepository<Food> foodRepository, IRepository<RecipeIngredient> recipeIngredientRepository)
            {
                _foodRepository = foodRepository;
                _recipeIngredientRepository = recipeIngredientRepository;
            }

            /// <summary>
            /// Handle deleting food
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <exception cref="FoodInUseException">If food is used in any recipes</exception>
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var food = await _foodRepository.GetByIdAsync(request.Id);
                Guard.AgainstNull(food, nameof(Command.Id), "Food not found");
                var usedIn = await _recipeIngredientRepository.ToListAsync(r => r.FoodId == request.Id, nameof(RecipeIngredient.Recipe));
                if (usedIn.Any())
                {
                    throw new FoodInUseException(usedIn);
                }
                await _foodRepository.DeleteAsync(food);
                return Unit.Value;
            }
        }
    }
}
