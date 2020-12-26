using FoodApp.Core.Domain.Accounts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodApp.Data
{
    public class DataContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DataContext(
         DbContextOptions options,
         IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
