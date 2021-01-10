using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class CreateNewFoodHandler : IRequestHandler<CreateNewFood, Shared.Models.Foods.Food>
    {
        private readonly IRepository<Core.Domain.Foods.Food> _foodRepository;
        private readonly IQuantityTypeService _quantityTypeService;
        

        public CreateNewFoodHandler(
            IRepository<Core.Domain.Foods.Food> foodRepository, 
            IQuantityTypeService quantityTypeService
        )
        {
            _foodRepository = foodRepository;
            _quantityTypeService = quantityTypeService;
        }

        public async Task<Shared.Models.Foods.Food> Handle(CreateNewFood request, CancellationToken cancellationToken = default)
        {
            QuantityType quantityType = await _quantityTypeService.EnsureCreatedAsync(request.QuantityType);

            // No duplicates - if exists, let user handle
            Core.Domain.Foods.Food existingFood = await _foodRepository.FindAsync(f => f.Name == request.Name);
            if (existingFood != null)
            {
                throw new ArgumentException(nameof(Shared.Models.Foods.Food.Name));
            }

            // Create the food
            var food = Core.Domain.Foods.Food.CreateNew(request.Name, request.AmountOnHand, quantityType);
            await _foodRepository.AddAsync(food);
            return new Shared.Models.Foods.Food
            {
                AmountOnHand = food.AmountOnHand,
                Id = food.Id,
                Name = food.Name,
                QuantityType = food.QuantityType.Type
            };
        }
    }
}
