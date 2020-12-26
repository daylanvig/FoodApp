using FoodApp.Core.Domain.Accounts;
using FoodApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodApp.Server.Configuration
{
    public class ServiceConfiguration
    {
        /// <summary>
        /// Configures the specified services. This method calls all service configuration methods
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(
                    configuration.GetConnectionString("Default"), 
                    ServerVersion.FromString("8.0.17"), 
                    o => o.MigrationsAssembly(typeof(DataContext).Assembly.FullName)
                    )
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            });

            ConfigureIdentity(services);

            return services;
        }

        protected static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DataContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, DataContext>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();
        }
    }
}
