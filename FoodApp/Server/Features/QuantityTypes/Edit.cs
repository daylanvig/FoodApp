using AutoMapper;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.QuantityTypes
{
    /// <summary>
    /// Edit QuantityType Feature
    /// </summary>
    public class Edit
    {
        /// <summary>
        /// Edit QuantityType Command
        /// </summary>
        public record Command(int Id, string Type) : IRequest<QuantityTypeModel>;

        /// <summary>
        /// Edit QuantityType Handler
        /// </summary>
        public class Handler : IRequestHandler<Command, QuantityTypeModel>
        {
            private readonly IRepository<QuantityType> _quantityTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IRepository<QuantityType> quantityTypeRepository, IMapper mapper)
            {
                _quantityTypeRepository = quantityTypeRepository;
                _mapper = mapper;
            }

            /// <summary>
            /// Handle editing the quantity type
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns>The newly edited quantity type</returns>
            public async Task<QuantityTypeModel> Handle(Command request, CancellationToken cancellationToken = default)
            {
                // Here we load quantity types that have the same name for duplicate checks, or same id for updating (reduce a query)
                var quantityTypes = await _quantityTypeRepository.ToListAsync(f =>
                                                        f.Type.ToLower() == request.Type.ToLower() ||
                                                        f.Id == request.Id);

                var quantityType = quantityTypes.SingleOrDefault(q => q.Id == request.Id);
                Guard.AgainstNull(quantityType, nameof(QuantityType.Id), "QuantityType does not exist.");

                // Has same name but isn't the one we're editing
                var duplicateQuantityType = quantityTypes.SingleOrDefault(f => f.Id != request.Id);
                Guard.ShouldBeNull(duplicateQuantityType, nameof(Command.Type), $"QuantityType name is in use (ID = {duplicateQuantityType?.Id})");
                quantityType!.UpdateType(request.Type);
                await _quantityTypeRepository.EditAsync(quantityType);
                return _mapper.Map<QuantityType, QuantityTypeModel>(quantityType);
            }
        }
    }
}
