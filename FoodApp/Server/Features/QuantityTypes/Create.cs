﻿using AutoMapper;
using FoodApp.Core.Common.Guards;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Services.Foods;
using FoodApp.Shared.Models.Foods;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.QuantityTypes
{
    /// <summary>
    /// Create QuantityType Feature
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Create QuantityType Command
        /// </summary>
        public record Command(string Type) : IRequest<QuantityTypeModel>;

        /// <summary>
        /// Create QuantityType Handler
        /// </summary>
        public class Handler : IRequestHandler<Command, QuantityTypeModel>
        {
            private readonly IQuantityTypeService _quantityTypeService;
            private readonly IMapper _mapper;

            public Handler(IQuantityTypeService quantityTypeService, IMapper mapper)
            {
                _quantityTypeService = quantityTypeService;
                _mapper = mapper;
            }

            /// <summary>
            /// Handle creating a quantity type
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<QuantityTypeModel> Handle(Command request, CancellationToken cancellationToken = default)
            {
                Guard.AgainstNull(request, nameof(Command));
                var quantityType = await _quantityTypeService.EnsureCreatedAsync(request.Type);
                return _mapper.Map<QuantityType, QuantityTypeModel>(quantityType);
            }
        }
    }
}
