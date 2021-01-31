using AutoMapper;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    /// <summary>
    /// Load Food Detail Feature
    /// </summary>
    public class Details
    {
        /// <summary>
        /// Load Food Details Query
        /// </summary>
        public record Query(int Id) : IRequest<FoodModel>;

        /// <summary>
        /// Load Food Details Handler
        /// </summary>
        public class Handler : IRequestHandler<Query, FoodModel>
        {
            private readonly IRepository<Food> _foodRepository;
            private readonly IMapper _mapper;

            public Handler(IRepository<Food> foodRepository, IMapper mapper)
            {
                _foodRepository = foodRepository;
                _mapper = mapper;
            }

            /// <summary>
            /// Handle loading Food
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>Loaded food</returns>
            /// <exception cref="System.ArgumentException">Thrown if food with matching id is not found</exception>
            public async Task<FoodModel> Handle(Query request, CancellationToken cancellationToken = default)
            {
                Food food = await _foodRepository.GetByIdAsync(request.Id, nameof(Food.QuantityType));
                Guard.AgainstNull(food, nameof(food.Id), "Food not found");
                return _mapper.Map<FoodModel>(food);
            }
        }
    }

}
