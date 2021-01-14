using FoodApp.Core.Interfaces;
using FoodApp.Data.Repositories;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    /// <summary>
    /// Get users foods
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{FoodApp.Server.Features.Foods.GetMyFoods, System.Collections.Generic.IEnumerable{FoodApp.Shared.Models.Foods.FoodModel}}" />
    public class GetMyFoodsHandler : IRequestHandler<GetMyFoods, IEnumerable<FoodModel>>
    {
        private readonly IRepository<Core.Domain.Foods.Food> _foodRepository;

        public GetMyFoodsHandler(IRepository<Core.Domain.Foods.Food> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<IEnumerable<FoodModel>> Handle(GetMyFoods request, CancellationToken cancellationToken)
        {
            var foods = await _foodRepository.ToListAsync(includes: nameof(Core.Domain.Foods.Food.QuantityType));

            return foods.Select(f => new FoodModel
            {
                Id = f.Id,
                Name = f.Name,
                QuantityType = f.QuantityType.Type,
                AmountOnHand = f.AmountOnHand,
            });
        }
    }
}
