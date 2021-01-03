using AutoMapper.Internal;

namespace Tests.FoodApp.TestInfrastructure
{
    public static class TestHelpers
    {
        public static TProperty GetPrivateValue<TEnity, TProperty>(TEnity instance, string propertyName)
        {
            var member = instance.GetType().GetFieldOrProperty(propertyName);
            return (TProperty) member.GetMemberValue(instance);
        }

        public static void SetPrivateValue<TEntity>(TEntity instance, string propertyName, object propertyValue)
        {
            var member = instance.GetType().GetFieldOrProperty(propertyName);
            member.SetMemberValue(instance, propertyValue);
        }
    }
}
