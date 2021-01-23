using AutoMapper;
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
            private readonly IMapper _mapper;

            public Handler(IRepository<Food> foodRepository, IMapper mapper)
            {
                _foodRepository = foodRepository;
                _mapper = mapper;
            }

            public async Task<FoodModel> Handle(Query request, CancellationToken cancellationToken = default)
            {
                Food food = await _foodRepository.GetByIdAsync(request.Id, nameof(Food.QuantityType));
                Guard.AgainstNull(food, nameof(food.Id), "Food not found");
                return _mapper.Map<FoodModel>(food);
            }
        }
    }

}
