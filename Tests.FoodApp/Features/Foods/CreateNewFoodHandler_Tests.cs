using FoodApp.Core.Domain.Foods;
using FoodApp.Services.Foods;
using Moq;
using System;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;
using static FoodApp.Server.Features.Foods.Create;

namespace Tests.FoodApp.Features.Foods
{
    public class CreateNewFoodHandler_Tests : DefaultTestFixture<Handler>
    {
        private readonly Command _create = new("Food", 0, "QT");

        public CreateNewFoodHandler_Tests()
        {
            DoMock<IQuantityTypeService, Task<QuantityType>>(Task.FromResult(CreateEntity.CreateExistingQuantityType("QT")));
        }

        [Fact]
        public async Task ThrowAnArgumentExceptionWhenFoodNameNotUnique()
        {
            // Arrange
            SetMock(CreateRepositoryMock.CreateRepository(new Food()));
            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => Sut.Handle(_create));
        }

        [Fact]
        public async Task CallAddAsyncWithAFood()
        {
            // Arrange
            var foodRepositoryMock = CreateRepositoryMock.CreateRepository<Food>();
            SetMock(foodRepositoryMock);
            // Act
            await Sut.Handle(_create);
            // Assert
            foodRepositoryMock.Verify(m => m.AddAsync(It.IsAny<Food>()), Times.Once);
        }
    }
}
