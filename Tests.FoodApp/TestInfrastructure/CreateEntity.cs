using FoodApp.Core.Domain.Foods;

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
    }
}
