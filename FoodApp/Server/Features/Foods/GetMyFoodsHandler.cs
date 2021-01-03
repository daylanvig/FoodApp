using FoodApp.Data.Repositories;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class GetMyFoodsHandler : IRequestHandler<GetMyFoods, IEnumerable<Food>>
    {
        private readonly IRepository<Core.Domain.Foods.Food> _foodRepository;

        public GetMyFoodsHandler(IRepository<Core.Domain.Foods.Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public async Task<IEnumerable<Food>> Handle(GetMyFoods request, CancellationToken cancellationToken)
        {
            var foods = await _foodRepository.ToListAsync(includes: nameof(Core.Domain.Foods.Food.QuantityType));

            return foods.Select(f => new Food
            {
                Id = f.Id,
                Name = f.Name,
                QuantityType = f.QuantityType.Type,
                AmountOnHand = f.AmountOnHand,
            });
        }
    }
}
