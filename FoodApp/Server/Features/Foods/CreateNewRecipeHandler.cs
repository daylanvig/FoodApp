﻿using FoodApp.Shared.Models.Foods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class CreateNewRecipe : IRequest<RecipeModel>
    {
        // todo
    }

    public class CreateNewRecipeHandler : IRequestHandler<CreateNewRecipe, RecipeModel>
    {
        public Task<RecipeModel> Handle(CreateNewRecipe request, CancellationToken cancellationToken = default)
        {

            throw new NotImplementedException();
        }
    }
}
