using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.QuantityTypes
{
    /// <summary>
    /// Delete QuantityType Feature
    /// </summary>
    public class Delete
    {
        /// <summary>
        /// Delete QuantityType Command
        /// </summary>
        public record Command(int Id) : IRequest;

        /// <summary>
        /// Delete QuantityType Handler
        /// </summary>
        public class Handler : IRequestHandler<Command>
        {
            private readonly IRepository<QuantityType> _quantityTypeRepository;

            public Handler(IRepository<QuantityType> quantityTypeRepository)
            {
                _quantityTypeRepository = quantityTypeRepository;
            }

            /// <summary>
            /// Handle deleting a quantity type
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <exception cref="System.ArgumentException">Thrown if quantity type with id is not found</exception>
            /// <exception cref="QuantityTypeInUseException">Thrown if any foods/recipes use the quantity type</exception>
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var quantityType = await _quantityTypeRepository
                    .GetByIdAsync(request.Id, 
                    $"{nameof(QuantityType.RecipeIngredients)}.{nameof(RecipeIngredient.Recipe)}", 
                    nameof(QuantityType.Foods)
                );
                Guard.AgainstNull(quantityType, nameof(Command.Id), "QuantityType not found");

                quantityType.CheckIfCanBeDeleted();

                await _quantityTypeRepository.DeleteAsync(quantityType);

                return Unit.Value;
            }
        }
    }
}
