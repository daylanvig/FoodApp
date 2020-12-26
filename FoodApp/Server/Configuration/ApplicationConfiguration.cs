using Microsoft.AspNetCore.Builder;

namespace FoodApp.Server.Configuration
{
    public class ApplicationConfiguration
    {
        public static void Configure(IApplicationBuilder app, bool isDevelopment)
        {
            if (isDevelopment)
            {
                ConfigureDevelopment(app);
            }
            else
            {
                ConfigureProduction(app);
            }
            
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            // Identity - Must be called after UseRouting and before UseEndpoints
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }


        private static void ConfigureDevelopment(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseWebAssemblyDebugging();
        }

        private static void ConfigureProduction(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
    }
}
