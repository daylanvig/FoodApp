using MediatR;

namespace FoodApp.Server.Features.Foods
{
    public class EditFood : IRequest<Shared.Models.Foods.Food>
    {
        public EditFood(int id, string name, decimal amountOnHand, string quantityType)
        {
            Id = id;
            Name = name;
            AmountOnHand = amountOnHand;
            QuantityType = quantityType;
        }
        public int Id { get; }
        public string Name { get; }
        public decimal AmountOnHand { get; }
        public string QuantityType { get; }
    }
}
