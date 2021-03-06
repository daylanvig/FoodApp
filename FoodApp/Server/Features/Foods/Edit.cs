﻿using AutoMapper;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    /// <summary>
    /// Edit Food Feature
    /// </summary>
    public class Edit
    {
        /// <summary>
        /// Edit Food Command
        /// </summary>
        public record Command(int Id, string Name, decimal AmountOnHand, string QuantityType) : IRequest<FoodModel>;

        /// <summary>
        /// Edit Food Handler
        /// </summary>
        public class EditFoodHandler : IRequestHandler<Command, FoodModel>
        {
            private readonly IRepository<Food> _foodRepository;
            private readonly IQuantityTypeService _quantityTypeService;
            private readonly IMapper _mapper;

            public EditFoodHandler(
                IRepository<Food> foodRepository,
                IQuantityTypeService quantityTypeService,
                IMapper mapper)
            {
                _foodRepository = foodRepository;
                _quantityTypeService = quantityTypeService;
                _mapper = mapper;
            }

            /// <summary>
            /// Handle editing food
            /// </summary>
            /// <param name="command"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<FoodModel> Handle(Command command, CancellationToken cancellationToken = default)
            {
                // quantity type is updated independently
                await _quantityTypeService.EnsureCreatedAsync(command.QuantityType);

                Food existingFood = await _foodRepository.GetByIdAsync(command.Id);
                Guard.AgainstNull(existingFood, nameof(Command.Id), "Food not found");
                existingFood.UpdateName(command.Name);
                existingFood.UpdateQuantityOnHand(command.AmountOnHand);
                await _foodRepository.EditAsync(existingFood);
                return _mapper.Map<FoodModel>(existingFood);
            }
        }
    }
}
