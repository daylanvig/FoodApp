using FoodApp.Core.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodApp.Data
{
    public class DataContextFactory 
    {
        private readonly ITenantProvider _tenantProvider;
        private readonly DbContextOptions<DataContext> _dbContextOptions;
        

        public DataContextFactory(ITenantProvider tenantProvider, DbContextOptions<DataContext> dbContextOptions)
        {
            _tenantProvider = tenantProvider;
            _dbContextOptions = dbContextOptions;
        }

        public IDataContext CreateDbContext()
        {
            return new DataContext(_dbContextOptions, _tenantProvider.GetTenantId());
        }
    }
}
