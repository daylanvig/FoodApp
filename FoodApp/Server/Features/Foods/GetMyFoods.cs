using MediatR;
using System.Collections.Generic;

namespace FoodApp.Server.Features.Foods
{
    public class GetMyFoods : IRequest<IEnumerable<Shared.Models.Foods.Food>>
    {
    }
}
