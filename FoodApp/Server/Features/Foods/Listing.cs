using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class Listing
    {
        public record Query() : IRequest<IEnumerable<FoodModel>>;
        /// <summary>
        /// Get users foods
        /// </summary>
        /// <seealso cref="MediatR.IRequestHandler{GetMyFoods, IEnumerable{FoodApp.Shared.Models.Foods.FoodModel}}" />
        public class Handler : IRequestHandler<Query, IEnumerable<FoodModel>>
        {
            private readonly IRepository<Food> _foodRepository;

            public Handler(IRepository<Food> foodRepository)
            {
                _foodRepository = foodRepository;
            }

            public async Task<IEnumerable<FoodModel>> Handle(Query request, CancellationToken cancellationToken = default)
            {
                var foods = await _foodRepository.ToListAsync(includes: nameof(Food.QuantityType));

                return foods.Select(f => new FoodModel(f.Id, f.Name, f.AmountOnHand, f.QuantityType.Type));
            }
        }
    }
}
