using FoodApp.Core.Interfaces;
using FoodApp.Services.Accounts;
using FoodApp.Services.Foods;
using Microsoft.Extensions.DependencyInjection;

namespace FoodApp.Services
{
    public static class ConfigureService
    {

        public static void AddFoodAppServices(this IServiceCollection services)
        {
            services.AddTransient<ITenantProvider, TenantProvider>();
            services.AddScoped<IQuantityTypeService, QuantityTypeService>();
        }
    }
}
