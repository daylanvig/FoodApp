using AutoFixture.Xunit2;
using FoodApp.Core.Domain.Foods;
using FoodApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Data
{
    public class DataContextExtensions_Test_Base
    {
        protected readonly DataContext sut;
        protected const string TENANT_ID = "TENANT1";
        public DataContextExtensions_Test_Base()
        {
            var fixture = DefaultTestFixture<DataContext>.Create();
            sut = fixture.AddInMemoryDatabase<DataContext>(TENANT_ID);
        }
    }

    public class SetApplicationUserId_Tests : DataContextExtensions_Test_Base
    {
        [Fact]
        public void Should_set_tenantId_on_entity()
        {
            // Arrange
            Food food = new();
            sut.Add(food);
            // Act
            sut.SetApplicationUserId(TENANT_ID);
            // Assert
            Assert.Equal(TENANT_ID, TestHelpers.GetPrivateValue<Food, string>(food, "_applicationUserId"));
        }
    }
}
