using FoodApp.Core.Domain.Accounts;
using FoodApp.Core.Interfaces;
using FoodApp.Data;
using FoodApp.Data.Repositories;
using FoodApp.Services.Accounts;
using MediatR;
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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
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
            services.AddScoped<IDataContext>(s => s.GetRequiredService<DataContextFactory>().CreateDbContext());

            services.AddMediatR(typeof(Startup));
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
