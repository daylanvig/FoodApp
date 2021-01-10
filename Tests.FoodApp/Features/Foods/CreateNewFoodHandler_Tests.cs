using FoodApp.Core.Domain.Foods;
using FoodApp.Server.Features.Foods;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Features.Foods
{
    public class CreateNewFoodHandler_Tests : DefaultTestFixture<CreateNewFoodHandler>
    {
        private readonly CreateNewFood _create = new CreateNewFood("Food", 0, "QT");

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
