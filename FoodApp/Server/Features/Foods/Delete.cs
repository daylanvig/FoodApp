using FoodApp.Core.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class Delete
    {
        public record Command(int Id) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly IRepository<Food> _foodRepository;

            public Handler(IRepository<Food> foodRepository)
            {
                _foodRepository = foodRepository;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var food = await _foodRepository.GetByIdAsync(request.Id);
                Guard.AgainstNull(food, nameof(Command.Id), "Food not found");
                await _foodRepository.DeleteAsync(food);
                return Unit.Value;
            }
        }
    }
}
