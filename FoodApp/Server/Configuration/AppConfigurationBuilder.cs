using Microsoft.Extensions.Configuration;
using System.IO;

namespace FoodApp.Server.Configuration
{
    public class AppConfigurationBuilder
    {
        /// <summary>
        /// Gets the configuration builder for app default
        /// </summary>
        /// <returns></returns>
        public static IConfigurationBuilder GetConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(typeof(Program).Assembly);
        }
    }
}
