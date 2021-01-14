using FoodApp.Shared.Models.Foods;
using MediatR;

namespace FoodApp.Server.Features.Foods
{
    public class GetFood : IRequest<FoodModel>
    {
        public GetFood(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
