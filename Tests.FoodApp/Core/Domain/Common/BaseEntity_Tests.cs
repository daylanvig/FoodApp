using Core;
using Core.Domain.Common;
using FoodApp.Data;
using System.Linq;
using Xunit;

namespace Tests.FoodApp.Core.Domain.Common
{
    public class BaseEntity_Tests
    {
        [Fact]
        public void All_base_entities_should_have_db_sets()
        {
            // Arrange
            var database = typeof(DataContext);
            var properties = database.GetProperties().Where(p => p.PropertyType.Name.Contains("DbSet")).ToList();
            var baseEntityTypes = typeof(BaseEntity).Assembly.GetExportedTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BaseEntity))).ToList();
            // Act
            foreach (var baseEntity in baseEntityTypes)
            {
                var property = properties.Where(p => p.PropertyType.GetGenericArguments()[0] == baseEntity);
                Assert.Single(property);
            }
        }
    }


    public class BaseEntity_IsCreated
    {
        private class TestBaseEntity : BaseEntity
        {
            public void RunIsCreated()
            {
                IsCreated();
            }
        }

        private TestBaseEntity _sut;
        public BaseEntity_IsCreated()
        {
            _sut = new TestBaseEntity();
        }


        [Fact]
        public void Should_throw_an_error_when_id_is_0()
        {
            // Arrange
            _sut.Id = 0;
            // Act + Assert
            Assert.Throws<EntityIsNotCreatedException>(() => _sut.RunIsCreated());
        }

        [Fact]
        public void Should_not_throw_any_errors()
        {
            // Arrange
            _sut.Id = 1;
            // Act
            _sut.RunIsCreated();
            // Assert 
            Assert.True(true); // ! XUnit removed "Assert.DoesNotThrow" and recommends just running test
        }
    }
}
