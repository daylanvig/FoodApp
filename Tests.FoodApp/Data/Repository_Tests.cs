using AutoFixture.Xunit2;
using Core.Domain.Common;
using FoodApp.Data;
using FoodApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.FoodApp.TestInfrastructure;
using Xunit;

namespace Tests.FoodApp.Data
{
    /// <summary>
    /// Base setup of tests
    /// </summary>
    public class Repository_Test_Base
    {
        protected readonly Repository<TestEntity> sut;

        // Test Data
        protected const string TENANT_ID = "TENANTID";
        protected DataContext testDatabase;
        public Repository_Test_Base()
        {
            var fixture = DefaultTestFixture<Repository<TestEntity>>.Create();
            testDatabase = fixture.AddInMemoryDatabase<TestDatabaseContext>(TENANT_ID);
            sut = fixture.CreateSut();
        }
    }

    public class Repository_GetByIdAsync_Tests : Repository_Test_Base
    {
        [Theory, AutoData]
        public void Should_return_null_if_no_entity_has_same_id(int id)
        {
            // Arrange N/A (no items)
            // Act
            var result = sut.GetByIdAsync(id).Result;
            // Assert
            Assert.Null(result);
        }

        [Theory, AutoData]
        public void Should_return_one_item_from_database(TestEntity testEntity)
        {
            // Arrange
            testDatabase.Add(testEntity);
            testDatabase.SaveChanges();
            // Act
            var result = sut.GetByIdAsync(testEntity.Id).Result;
            // Assert
            Assert.NotNull(result);
            Assert.Equal(testEntity.Id, result.Id);
        }
    }

    public class Repository_ToListAsync_Tests: Repository_Test_Base
    {
        [Theory, AutoData]
        public void Should_return_all_items(IEnumerable<TestEntity> entities)
        {
            // Arrange
            testDatabase.AddRange(entities);
            testDatabase.SaveChanges();
            // Act
            var result = sut.ToListAsync().Result;
            // Assert
            Assert.Equal(entities.Count(), result.Count());
        }

        [Fact]
        public void Should_return_no_items()
        {
            Assert.Empty(sut.ToListAsync().Result);
        }

        [Theory, AutoData]
        public void Should_return_one_item(List<TestEntity> entities)
        {
            // Arrange
            entities[0].CreatedOn = new DateTimeOffset(2020, 2, 2, 8, 0, 0, TimeSpan.Zero);
            testDatabase.AddRange(entities);
            testDatabase.SaveChanges();
            // Act
            var result = sut.ToListAsync(e => e.CreatedOn == entities[0].CreatedOn).Result;
            // Assert
            Assert.Single(result);
        }
    }


    public class TestEntity : BaseEntity
    {

    }

    public class TestDatabaseContext : DataContext
    {
        public TestDatabaseContext(DbContextOptions<DataContext> options, string tenantId) : base(options, tenantId)
        {
        }

        public DbSet<TestEntity> Entites { get; set; }
    }
}
