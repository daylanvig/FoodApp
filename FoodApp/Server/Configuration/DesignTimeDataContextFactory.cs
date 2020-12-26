using FoodApp.Data;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FoodApp.Server.Configuration
{
    public class DesignTimeDataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = AppConfigurationBuilder
                                            .GetConfigurationBuilder()
                                            .Build();

            IOptions<OperationalStoreOptions> options = Options.Create(new OperationalStoreOptions());
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseMySql(configuration.GetConnectionString("Default"), ServerVersion.FromString("8.0.17"));
            return new DataContext(optionsBuilder.Options, options);
        }
    }
}
