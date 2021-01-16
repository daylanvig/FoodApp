using FoodApp.Core.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class Edit
    {
        public record Command(int Id, string Name, decimal AmountOnHand, string QuantityType) : IRequest<FoodModel>;

        public class EditFoodHandler : IRequestHandler<Command, FoodModel>
        {
            private readonly IRepository<Food> _foodRepository;
            private readonly IQuantityTypeService _quantityTypeService;
            public EditFoodHandler(
                IRepository<Food> foodRepository,
                IQuantityTypeService quantityTypeService)
            {
                _foodRepository = foodRepository;
                _quantityTypeService = quantityTypeService;
            }

            public async Task<FoodModel> Handle(Command command, CancellationToken cancellationToken = default)
            {
                // quantity type is updated independently
                var quantityType = await _quantityTypeService.EnsureCreatedAsync(command.QuantityType);

                Food existingFood = await _foodRepository.GetByIdAsync(command.Id);
                Guard.AgainstNull(existingFood, nameof(Command.Id), "Food not found");

                existingFood.UpdateName(command.Name);
                existingFood.UpdateQuantityOnHand(command.AmountOnHand);
                await _foodRepository.EditAsync(existingFood);
                return new FoodModel(existingFood.Id, existingFood.Name, existingFood.AmountOnHand, quantityType.Type);
            }
        }
    }
}
