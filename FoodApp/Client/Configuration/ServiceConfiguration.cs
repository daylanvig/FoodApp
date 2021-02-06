using FoodApp.Client.Services;
using FoodApp.Client.Services.System;
using Microsoft.Extensions.DependencyInjection;

namespace FoodApp.Client.Configuration
{
    public static class ServiceConfiguration
    {

        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IDomParser, DomParser>();
            services.AddScoped<IApiRequestService, ApiRequestService>();
            services.AddScoped<IEntityCache, EntityCache>();
        }
    }
}
