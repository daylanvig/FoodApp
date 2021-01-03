using AutoFixture.Xunit2;
using FoodApp.Core.Domain.Foods;
using Xunit;

namespace Tests.FoodApp.Core.Domain.Foods
{
    public class QuantityType_CreateNew_Tests
    {
        [Theory, AutoData]
        public void SetsTypeOnCreate(string typeName)
        {
            // Act
            var quanityType = QuantityType.CreateNew(typeName);
            // Assert
            Assert.Equal(typeName, quanityType.Type);
        }
    }
}
