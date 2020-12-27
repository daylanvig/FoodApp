using FoodApp.Core.Domain.Accounts;
using FoodApp.Data;
using FoodApp.Services.Accounts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

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
            services.AddTransient<DataContextFactory>();

            services.AddDbContext<ApplicationUserContext>(options =>
            {
                options.UseMySql(
                      configuration.GetConnectionString("Users"),
                      ServerVersion.FromString("8.0.17"),
                      o => o.MigrationsAssembly(typeof(ApplicationUserContext).Assembly.FullName)
                      )
                      .EnableDetailedErrors()
                      .EnableSensitiveDataLogging();
            });

            services.AddDbContextFactory<DataContext>(options =>
            {
                options.UseMySql(
                   configuration.GetConnectionString("Default"),
                   ServerVersion.FromString("8.0.17"),
                   o => o.MigrationsAssembly(typeof(DataContext).Assembly.FullName)
                   )
                   .EnableDetailedErrors()
                   .EnableSensitiveDataLogging();
            });
            //services.AddDbContext<DataContext>(options =>
            //{
            //    options.UseMySql(
            //       configuration.GetConnectionString("Users"),
            //       ServerVersion.FromString("8.0.17"),
            //       o => o.MigrationsAssembly(typeof(DataContext).Assembly.FullName)
            //       )
            //       .EnableDetailedErrors()
            //       .EnableSensitiveDataLogging();
            //}, ServiceLifetime.Scoped);
            services.AddScoped<IDataContext>(s => s.GetRequiredService<DataContextFactory>().CreateDbContext());
            ConfigureIdentity(services);

            return services;
        }

        protected static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationUserContext>();
            services.Configure<IdentityOptions>(o => o.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationUserContext>()
                .AddProfileService<ProfileService>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();
        }
    }
}
