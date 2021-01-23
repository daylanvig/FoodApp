﻿using FoodApp.Core.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.QuantityTypes
{
    public class Delete
    {
        public record Command(int Id) : IRequest;

        public class Handler : IRequestHandler<Command>
        {
            private readonly IRepository<QuantityType> _quantityTypeRepository;

            public Handler(IRepository<QuantityType> quantityTypeRepository)
            {
                _quantityTypeRepository = quantityTypeRepository;
            }

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