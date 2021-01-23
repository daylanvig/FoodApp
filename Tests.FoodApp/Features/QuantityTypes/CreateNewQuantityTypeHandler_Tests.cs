using FoodApp.Core.Domain.QuantityTypes;
using FoodApp.Server.Features.QuantityTypes;
using FoodApp.Services.Foods;
using Moq;
using System;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Features.QuantityTypes
{
    public class CreateNewQuantityTypeHandler_Tests : DefaultTestFixture<Create.Handler>
    {
        private readonly Mock<IQuantityTypeService> _mockQuantityTypeService;
        public CreateNewQuantityTypeHandler_Tests()
        {
            _mockQuantityTypeService = DoMock<IQuantityTypeService, Task<QuantityType>>(
                Task.FromResult(CreateEntity.CreateExistingQuantityType("ExistingType")));
        }

        [Fact]
        public async Task ShouldThrowAnArgumentErrorWhenCommandIsNull()
        {
            // Act
            await Assert.ThrowsAsync<ArgumentException>(() => Sut.Handle(null));
        }

        [Fact]
        public async Task CallEnsureCreated()
        {
            // Act
            await Sut.Handle(new Create.Command("NewType"));
            // Assert
            _mockQuantityTypeService.Verify(m => m.EnsureCreatedAsync("NewType"), Times.Once);
        }
    }
}
