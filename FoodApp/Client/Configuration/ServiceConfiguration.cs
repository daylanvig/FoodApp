using FoodApp.Client.Services.System;
using Microsoft.Extensions.DependencyInjection;

namespace FoodApp.Client.Configuration
{
    public static class ServiceConfiguration
    {

        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IApiRequestService, ApiRequestService>();
        }
    }
}
