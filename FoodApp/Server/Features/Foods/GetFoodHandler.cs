﻿using FoodApp.Core.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class GetFoodHandler : IRequestHandler<GetFood, FoodModel>
    {
        private readonly IRepository<Food> _foodRepository;

        public GetFoodHandler(IRepository<Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<FoodModel> Handle(GetFood request, CancellationToken cancellationToken)
        {
            Food food = await _foodRepository.GetByIdAsync(request.Id, nameof(Food.QuantityType));
            Guard.AgainstNull(food, nameof(food.Id), "Food not found");
            return new FoodModel
            {
                AmountOnHand = food.AmountOnHand,
                Id = food.Id,
                Name = food.Name,
                QuantityType = food.QuantityType.Type
            };
        }
    }
}
