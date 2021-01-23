using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Core.Interfaces;
using FoodApp.Services.Foods;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Services
{
    public class QuantityTypeService_Tests : DefaultTestFixture<QuantityTypeService>
    {
        private readonly string _quantityTypeName = "QT";

        [Fact]
        public async Task NotCreateNewQuantityTypeWhenQuantityTypeExists()
        {
            // Arrange
            var existingType = CreateEntity.CreateExistingQuantityType("QT");
            var mockRepository = CreateRepositoryMock.CreateRepository(existingType);
            SetMock(mockRepository);
            // Act
            await Sut.EnsureCreatedAsync(_quantityTypeName);
            // Assert
            mockRepository.Verify(m => m.AddAsync(It.IsAny<QuantityType>()), Times.Never);
        }

        [Fact]
        public async Task CreateNewQuantityTypeWhenQuantityTypeDoesNotExist()
        {
            // Arrange
            var existingType = CreateEntity.CreateExistingQuantityType("QT");
            var mockRepository = CreateRepositoryMock.CreateRepository<QuantityType>();
            SetMock(mockRepository);
            // Act
            await Sut.EnsureCreatedAsync(_quantityTypeName);
            // Assert
            mockRepository.Verify(m => m.AddAsync(It.IsAny<QuantityType>()), Times.Once);
        }
    }
}
