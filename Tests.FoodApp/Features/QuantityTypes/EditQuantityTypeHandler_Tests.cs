using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Core.Interfaces;
using FoodApp.Server.Features.QuantityTypes;
using FoodApp.Services.Foods;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Features.QuantityTypes
{
    public class EditQuantityTypeHandler_Tests : DefaultTestFixture<Edit.Handler>
    {
        private readonly Mock<IRepository<QuantityType>> _mockQuantityTypeRepository;
        private readonly Edit.Command _editCommand = new(2, "NAME");
        public EditQuantityTypeHandler_Tests()
        {
            _mockQuantityTypeRepository = DoMockRepository<QuantityType>(null);
        }

        [Fact]
        public async Task ThrowAnArgumentExceptionWhenIdDoesNotExist()
        {
            // Arrange
            _mockQuantityTypeRepository.Setup(m => m.ToListAsync(It.IsAny<Expression<Func<QuantityType, bool>>>()))
                .ReturnsAsync(new List<QuantityType>
                {
                    CreateEntity.CreateExistingQuantityType("Name", 3)
                });

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>("Id", () => Sut.Handle(_editCommand));
        }

        [Fact]
        public async Task ThrowAnArgumentExceptionWhenNameIsInUseByADifferentQuantityType()
        {
            // Arrange
            _mockQuantityTypeRepository.Setup(m => m.ToListAsync(It.IsAny<Expression<Func<QuantityType, bool>>>()))
                .ReturnsAsync(new List<QuantityType>
                {
                    CreateEntity.CreateExistingQuantityType(_editCommand.Type, _editCommand.Id - 1),
                    CreateEntity.CreateExistingQuantityType("AName", _editCommand.Id),
                });

            // Act + Assert
            await Assert.ThrowsAsync<ArgumentException>("Type", () => Sut.Handle(_editCommand));
        }

        [Fact]
        public async Task NotThrowArgumentExceptionWhenNameIsInUseByCurrentQuantityType()
        {
            // Arrange
            _mockQuantityTypeRepository.Setup(m => m.ToListAsync(It.IsAny<Expression<Func<QuantityType, bool>>>()))
                .ReturnsAsync(new List<QuantityType>
                {
                    CreateEntity.CreateExistingQuantityType(_editCommand.Type, _editCommand.Id)
                });

            // Act (no assert for non-throwing)
            await Sut.Handle(_editCommand);
        }

        [Fact]
        public async Task SetTypeNameToBeNewTypeName()
        {
            // Arrange
            _mockQuantityTypeRepository.Setup(m => m.ToListAsync(It.IsAny<Expression<Func<QuantityType, bool>>>()))
              .ReturnsAsync(new List<QuantityType>
              {
                    CreateEntity.CreateExistingQuantityType("OriginalName", _editCommand.Id)
              });

            // Act
            await Sut.Handle(_editCommand);
            // Assert
            _mockQuantityTypeRepository.Verify(m => m.EditAsync(It.Is<QuantityType>(q => q.Type == _editCommand.Type)));
        }
    }
}
