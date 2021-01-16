using FluentValidation;
using FoodApp.Core.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    /// <summary>
    /// Create New Food
    /// </summary>
    public class Create
    {
        public record Command(string Name, decimal AmountOnHand, string QuantityType) : IRequest<FoodModel>;

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(c => c.Name)
                    .NotNull()
                    .NotEmpty()
                    .MaximumLength(150);

                RuleFor(c => c.AmountOnHand)
                    .GreaterThanOrEqualTo(0);

                RuleFor(c => c.QuantityType)
                    .NotEmpty()
                    .NotNull();
            }
        }

        public class Handler : IRequestHandler<Command, FoodModel>
        {

            private readonly IRepository<Food> _foodRepository;
            private readonly IQuantityTypeService _quantityTypeService;

            public Handler(
                IRepository<Food> foodRepository,
                IQuantityTypeService quantityTypeService
            )
            {
                _foodRepository = foodRepository;
                _quantityTypeService = quantityTypeService;
            }

            public async Task<FoodModel> Handle(Command request, CancellationToken cancellationToken = default)
            {
                QuantityType quantityType = await _quantityTypeService.EnsureCreatedAsync(request.QuantityType);

                // No duplicates - if exists, let user handle
                Food existingFood = await _foodRepository.FindAsync(f => f.Name == request.Name);
                if (existingFood != null)
                {
                    throw new ArgumentException("Food with that name already exists", nameof(FoodModel.Name));
                }

                // Create the food
                var food = Food.CreateNew(request.Name, request.AmountOnHand, quantityType);
                await _foodRepository.AddAsync(food);
                return new FoodModel(food.Id, food.Name, food.AmountOnHand, quantityType.Type);
            }
        }
    }

}
