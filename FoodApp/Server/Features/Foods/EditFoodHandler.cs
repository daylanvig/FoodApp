using FoodApp.Core.Common;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class EditFoodHandler : IRequestHandler<EditFood, Shared.Models.Foods.Food>
    {
        private readonly IRepository<Core.Domain.Foods.Food> _foodRepository;
        private readonly IQuantityTypeService _quantityTypeService;
        public EditFoodHandler(
            IRepository<Core.Domain.Foods.Food> foodRepository,
            IQuantityTypeService quantityTypeService)
        {
            _foodRepository = foodRepository;
            _quantityTypeService = quantityTypeService;
        }

        public async Task<Food> Handle(EditFood request, CancellationToken cancellationToken = default)
        {
            var quantityType = await _quantityTypeService.EnsureCreatedAsync(request.QuantityType);

            Core.Domain.Foods.Food existingFood = await _foodRepository.GetByIdAsync(request.Id);
            Guard.AgainstNull(existingFood, "Food not found");

            existingFood.UpdateName(request.Name);
            existingFood.UpdateQuantityOnHand(request.AmountOnHand);
            existingFood.UpdateQuantityType(quantityType);
            // todo -> edit and update

            return new Food
            {
                AmountOnHand = existingFood.AmountOnHand,
                Id = existingFood.Id,
                Name = existingFood.Name,
                QuantityType = existingFood.QuantityType.Type
            };
        }
    }
}
