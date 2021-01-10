using FoodApp.Core.Domain.Foods;
using FoodApp.Server.Features.Foods;
using FoodApp.Services.Foods;
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
    public class EditFoodHandler_Tests : DefaultTestFixture<EditFoodHandler>
    {
        private readonly EditFood _editFood = new EditFood(2, "food", 3, "qt");

        [Fact]
        public void EnsureQuantityTypeIsCreated()
        {
            // Arrange
            var mockQuantityTypeService = CreateMock.Default<QuantityTypeService, QuantityType>(CreateEntity.CreateExistingQuantityType("name", 2));
            // Act
            var result = Sut.Handle(_editFood).Result;
            // Assert
            mockQuantityTypeService.Verify(m => m.EnsureCreatedAsync(It.IsAny<string>()), Times.Once);
        }


        [Fact]
        public async Task ThrowAnArgumentExceptionIfGetByIdReturnsNull()
        {
            // Arrange
            var mockRepository = CreateRepositoryMock.CreateRepository<Food>();
            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => Sut.Handle(_editFood));
        }


        [Fact]
        public void CallEditAsyncWithFood()
        {
            // Arrange
            var mockRepository = CreateRepositoryMock.CreateRepository<Food>(CreateEntity.CreateExistingFood());
            // Act
            var _ = Sut.Handle(_editFood).Result;
            // Assert
            Assert.True(false);
        }

    }
}
