using FoodApp.Shared.Models.Foods;

namespace FoodApp.Client.Shared
{
    public static class StringConverter
    {
        public static string QuantityType(QuantityTypeModel quantityType) => quantityType.Type;
    }
}
