using FoodApp.Core.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class Details
    {
        public record Query(int Id) : IRequest<FoodModel>;

        public class Handler : IRequestHandler<Query, FoodModel>
        {
            private readonly IRepository<Food> _foodRepository;

            public Handler(IRepository<Food> foodRepository)
            {
                _foodRepository = foodRepository;
            }

            public async Task<FoodModel> Handle(Query request, CancellationToken cancellationToken = default)
            {
                Food food = await _foodRepository.GetByIdAsync(request.Id, nameof(Food.QuantityType));
                Guard.AgainstNull(food, nameof(food.Id), "Food not found");
                return new FoodModel(food.Id, food.Name, food.AmountOnHand, food.QuantityType.Type);
            }
        }
    }

}
