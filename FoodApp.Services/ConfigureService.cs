using FoodApp.Core.Interfaces;
using FoodApp.Services.Accounts;
using Microsoft.Extensions.DependencyInjection;

namespace FoodApp.Services
{
    public static class ConfigureService
    {

        public static void AddFoodAppServices(this IServiceCollection services)
        {
            services.AddTransient<ITenantProvider, TenantProvider>();
        }
    }
}
