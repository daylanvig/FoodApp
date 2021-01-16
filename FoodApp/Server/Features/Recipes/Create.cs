using FoodApp.Shared.Models.Foods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Recipes
{
    public class Create
    {
        public record Command() : IRequest<RecipeModel>;

        public class Handler : IRequestHandler<Command, RecipeModel>
        {
            public Task<RecipeModel> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
