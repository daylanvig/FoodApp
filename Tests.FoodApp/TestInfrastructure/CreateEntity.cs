using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Domain.QuantityTypes;

namespace Tests.FoodApp.TestInfrastructure
{
    public class CreateEntity
    {
        public static QuantityType CreateExistingQuantityType(string type, int id = 1)
        {
            var quantityType = QuantityType.CreateNew(type);
            quantityType.Id = id;
            return quantityType;
        }

        public static Food CreateExistingFood(string name = "food", decimal amountOnHand = 1, string quantityTypeName = "mL", int id = 1)
        {
            var food = Food.CreateNew(name, amountOnHand, CreateExistingQuantityType(quantityTypeName));
            food.Id = id;
            return food;
        }
    }
}
