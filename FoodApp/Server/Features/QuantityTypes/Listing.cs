using AutoMapper;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Core.Interfaces;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.QuantityTypes
{
    public class Listing
    {
        public record Query() : IRequest<IEnumerable<QuantityTypeModel>>;

        public class Handler : IRequestHandler<Query, IEnumerable<QuantityTypeModel>>
        {
            private readonly IRepository<QuantityType> _quantityTypeRepository;
            private readonly IMapper _mapper;

            public Handler(IRepository<QuantityType> quantityTypeRepository, IMapper mapper)
            {
                _quantityTypeRepository = quantityTypeRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<QuantityTypeModel>> Handle(Query request, CancellationToken cancellationToken = default)
            {
                var quantityTypes = await _quantityTypeRepository.ToListAsync();
                return _mapper.Map<QuantityTypeModel[]>(quantityTypes.OrderBy(q => q.Type));
            }
        }
    }
}
