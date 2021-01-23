using AutoMapper;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Collections.Generic;
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
        /// <seealso cref="MediatR.IRequestHandler{GetMyFoods, IEnumerable{FoodModel}}" />
        public class Handler : IRequestHandler<Query, IEnumerable<FoodModel>>
        {
            private readonly IRepository<Food> _foodRepository;
            private readonly IMapper _mapper;

            public Handler(IRepository<Food> foodRepository, IMapper mapper)
            {
                _foodRepository = foodRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<FoodModel>> Handle(Query request, CancellationToken cancellationToken = default)
            {
                var foods = await _foodRepository.ToListAsync(includes: nameof(Food.QuantityType));
                return _mapper.Map<IEnumerable<FoodModel>>(foods);
            }
        }
    }
}
