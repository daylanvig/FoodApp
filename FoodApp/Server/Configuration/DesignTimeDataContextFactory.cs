using FoodApp.Data;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FoodApp.Server.Configuration
{
	public class DesignTimeApplicationUserContextFactory : IDesignTimeDbContextFactory<ApplicationUserContext>
	{
		public ApplicationUserContext CreateDbContext(string[] args)
		{
			IConfiguration configuration = AppConfigurationBuilder
											.GetConfigurationBuilder()
											.Build();

			IOptions<OperationalStoreOptions> options = Options.Create(new OperationalStoreOptions());
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationUserContext>()
				.UseMySql(configuration.GetConnectionString("Users"), ServerVersion.FromString("8.0.17"), o => o.MigrationsAssembly(typeof(ApplicationUserContext).Assembly.FullName));
			return new ApplicationUserContext(optionsBuilder.Options, options);
		}
	}

	public class DesignTimeDataContextFactory : IDesignTimeDbContextFactory<DataContext>
	{
		public DataContext CreateDbContext(string[] args)
		{
			IConfiguration configuration = AppConfigurationBuilder
											.GetConfigurationBuilder()
											.Build();

			
			var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
				.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.FromString("8.0.17"), o => o.MigrationsAssembly(typeof(ApplicationUserContext).Assembly.FullName));
			return new DataContext(optionsBuilder.Options, "");
		}
	}
}
