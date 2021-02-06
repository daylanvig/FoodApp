using FoodApp.Core.Domain.Common;
using FoodApp.Core.Domain.Foods;
using FoodApp.Core.Domain.QuantityTypes;
using System;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Core.Domain.Foods
{
    public class Food_CreateNew_Tests
    {
        private const string NAME = "FoodName";
        private const decimal AMOUNT_ON_HAND = 10;
        private readonly QuantityType _quantityType = QuantityType.CreateNew("mL");
        private readonly Food _sut;

        public Food_CreateNew_Tests()
        {
            _sut = Food.CreateNew(NAME, AMOUNT_ON_HAND, _quantityType);
        }

        [Fact]
        public void SetNameToBeFoodName()
        {
            Assert.Equal(NAME, _sut.Name);
        }

        [Fact]
        public void SetAmountOnHandToBe10()
        {
            Assert.Equal(AMOUNT_ON_HAND, _sut.AmountOnHand);
        }

        [Fact]
        public void SetQuantityTypeToBemL()
        {
            Assert.Equal(_quantityType, _sut.QuantityType);
        }
    }


    public class Food_UpdateQuantityOnHand_Tests : Food_Test_Base
    {

        [Fact]
        public void SetAmountOnHandToBe37()
        {
            // Act
            Sut.UpdateQuantityOnHand(37);
            // Assert
            Assert.Equal(37, Sut.AmountOnHand);
        }

        [Fact]
        public void ThrowAnEntityIsNotCreatedException()
        {
            // Arrange
            Sut.Id = 0;
            // Act + Assert
            Assert.Throws<EntityIsNotCreatedException>(() => Sut.UpdateQuantityOnHand(1));
        }

        [Fact]
        public void ThrowAnExceptionOfFoodQuantityMustBeGreaterThanZero()
        {
            Assert.Throws<FoodQuantityMustBeGreaterThanZeroException>(() => Sut.UpdateQuantityOnHand(-1));
        }
    }

    public class Food_UpdateName_Tests : Food_Test_Base
    {
        [Fact]
        public void ShouldSetNameToBeBanana()
        {
            Sut.UpdateName("Banana");
            Assert.Equal("Banana", Sut.Name);
        }

        [Fact]
        public void ShouldThrowAnArgumentExceptionWhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => Sut.UpdateName(string.Empty));
        }
    }

    public class Food_UpdateQuantityType_Tests : Food_Test_Base
    {
        [Fact]
        public void ShouldSetQuantityType()
        {
            // Arrange
            var quantityType = QuantityType.CreateNew("T");
            // Act
            Sut.UpdateQuantityType(quantityType);
            // Assert
            Assert.Equal(quantityType, Sut.QuantityType);
        }

        [Fact]
        public void ShouldThrowAnArgumentExceptionWhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => Sut.UpdateQuantityType(null));
        }
    }

    public class Food_Test_Base : DefaultTestFixture<Food>
    {
        public override Food CreateSut()
        {
            var food = Food.CreateNew("Food", 5, QuantityType.CreateNew("mL"));
            food.Id = 1;
            food.SetApplicationUserId("123");
            return food;
        }
    }
}
