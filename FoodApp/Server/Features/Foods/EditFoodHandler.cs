using FoodApp.Shared.Models.Foods;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodApp.Server.Features.Foods
{
    public class EditFoodHandler : IRequestHandler<CreateNewFood, Shared.Models.Foods.Food>
    {
        public EditFoodHandler()
        {

        }
        public Task<Food> Handle(CreateNewFood request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
