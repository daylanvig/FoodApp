using FoodApp.Data;
using FoodApp.Server.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Tests.FoodApp.Data
{
    public class DataContext_Tests
    {
        [Fact]
        public void Can_be_created()
        {
            // Arrange
            IConfiguration cfg = AppConfigurationBuilder.GetConfigurationBuilder().Build();
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                                    .UseMySql(cfg.GetConnectionString("Test"), ServerVersion.AutoDetect(cfg.GetConnectionString("Test")), null);

            // Act
            using var context = new DataContext(optionsBuilder.Options, string.Empty);
            var isNewlyCreated = context.Database.EnsureCreated();
            var isDestroyed = context.Database.EnsureDeleted();
            // Assert
            Assert.True(isNewlyCreated);
            Assert.True(isDestroyed);
        }
    }
}
