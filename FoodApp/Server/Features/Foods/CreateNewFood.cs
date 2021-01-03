using MediatR;

namespace FoodApp.Server.Features.Foods
{
    public class CreateNewFood : IRequest<Shared.Models.Foods.Food>
    {
        public CreateNewFood(string name, decimal amountOnHand, string quantityType)
        {
            Name = name;
            AmountOnHand = amountOnHand;
            QuantityType = quantityType;
        }

        public string Name { get; }
        public decimal AmountOnHand { get; }
        public string QuantityType { get; }
    }
}
