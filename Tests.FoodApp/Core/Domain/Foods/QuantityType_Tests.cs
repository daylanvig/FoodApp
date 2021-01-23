using AutoFixture.Xunit2;
using Core;
using FoodApp.Core.Domain.Foods;
using System;
using Tests.FoodApp.TestInfrastructure;
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


    public class QuantityType_UpdateType_Tests
    {
        [Fact]
        public void ShouldThrowAnEntityIsNotCreatedExceptionWhenIdIs0()
        {
            // Arrange
            var quantityType = QuantityType.CreateNew("New");
            // Act + Assert
            Assert.Throws<EntityIsNotCreatedException>(() => quantityType.UpdateType("NewType"));
        }

        [Theory, AutoData]
        public void ShouldSetTypeToBeProvidedType(string type)
        {
            // Arrange
            var quantityType = CreateEntity.CreateExistingQuantityType("existingType");
            // Act
            quantityType.UpdateType(type);
            // Assert
            Assert.Equal(type, quantityType.Type);
        }

        [Fact]
        public void ThrowAnArgumentExceptionIfNewTypeIsEmpty()
        {
            // Arrange
            var quantityType = CreateEntity.CreateExistingQuantityType("existingType");
            // Act + Assert
            Assert.Throws<ArgumentException>(() => quantityType.UpdateType(string.Empty));
            
        }
    }
}
