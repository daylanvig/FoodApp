using FoodApp.Data;
using FoodApp.Server.Configuration;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace Tests.FoodApp.Data
{
    public class DataContext_Tests
    {
        [Fact]
        public void Can_be_created()
        {
            // Arrange
            IOptions<OperationalStoreOptions> operationalStoreOptions = Options.Create(new OperationalStoreOptions());
            IConfiguration cfg = AppConfigurationBuilder.GetConfigurationBuilder().Build();
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                                    .UseMySql(cfg.GetConnectionString("Test"), ServerVersion.AutoDetect(cfg.GetConnectionString("Test")), null);

            // Act
            using var context = new DataContext(optionsBuilder.Options, operationalStoreOptions);
            var isNewlyCreated = context.Database.EnsureCreated();
            var isDestroyed = context.Database.EnsureDeleted();
            // Assert
            Assert.True(isNewlyCreated);
            Assert.True(isDestroyed);
        }
    }
}
