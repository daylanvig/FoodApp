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
        private readonly EditFood _editFood = new EditFood(2, "editFoodHandleFoodName", 33, "editFoodHandlerQuantity");
        private readonly Mock<IQuantityTypeService> _mockQuantityTypeService;
        public EditFoodHandler_Tests()
        {
            _mockQuantityTypeService = DoMock<IQuantityTypeService, QuantityType>(CreateEntity.CreateExistingQuantityType("originalName", 2));
        }
        [Fact]
        public void EnsureQuantityTypeIsCreated()
        {
            // Arrange
            DoMockRepository(CreateEntity.CreateExistingFood());
            // Act
            var result = Sut.Handle(_editFood).Result;
            // Assert
            _mockQuantityTypeService.Verify(m => m.EnsureCreatedAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ThrowAnArgumentExceptionIfGetByIdReturnsNull()
        {
            // Arrange
            var mockRepository = CreateRepositoryMock.CreateRepository<Food>();
            SetMock(mockRepository);
            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>(() => Sut.Handle(_editFood));
        }

        [Fact]
        public void CallEditAsyncWithFood()
        {
            // Arrange
            var mockRepository = DoMockRepository(CreateEntity.CreateExistingFood());
            // Act
            var _ = Sut.Handle(_editFood).Result;
            // Assert
            mockRepository.Verify(m => m.EditAsync(It.IsAny<Food>()), Times.Once);
        }


        [Fact]
        public void UpdateFoodName()
        {
            // Arrange
            DoMockRepository(CreateEntity.CreateExistingFood());
            // Act
            var result = Sut.Handle(_editFood).Result;
            // Assert
            Assert.Equal(_editFood.Name, result.Name);
        }

        [Fact]
        public void UpdateAmountOnHand()
        {
            // Arrange
            DoMockRepository(CreateEntity.CreateExistingFood());
            // Act
            var result = Sut.Handle(_editFood).Result;
            // Assert
            Assert.Equal(_editFood.AmountOnHand, result.AmountOnHand);
        }
    }
}
