using FoodApp.Client.Configuration;
using FoodApp.Client.Services.System;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");



            builder.Services.AddHttpClient("FoodApp.ServerAPI", c => c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                            .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FoodApp.ServerAPI"));
            builder.Services.AddApiAuthorization()
                    .AddAccountClaimsPrincipalFactory<CustomUserFactory>();
            builder.Services.AddAppServices();
            builder.Services
                .AddMudBlazorDialog()
                .AddMudBlazorSnackbar(c =>
                {
                    c.PositionClass = Defaults.Classes.Position.BottomCenter;
                    c.SnackbarVariant = Variant.Filled;
                })
                .AddMudBlazorResizeListener();
            await builder.Build().RunAsync();
        }
    }
}
