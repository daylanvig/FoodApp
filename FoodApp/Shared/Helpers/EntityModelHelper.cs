using FoodApp.Shared.Models.Foods;

namespace FoodApp.Shared.Helpers
{
    public static class EntityModelHelper
    {
        public static bool IsNew(IEntityModel model)
        {
            return model.Id == 0;
        }
    }
}
