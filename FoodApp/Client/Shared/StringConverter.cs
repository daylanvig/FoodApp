using FoodApp.Shared.Models.Foods;

namespace FoodApp.Client.Shared
{
    /// <summary>
    /// StringConverters for use with Mud framework
    /// </summary>
    public static class StringConverter
    {
        public static string QuantityType(QuantityTypeModel quantityType) => quantityType.Type;
    }
}
