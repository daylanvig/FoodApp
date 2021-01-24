using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Client.Services.System
{
    public interface IEntityCache
    {
        Task CacheList<TEntity>(IEnumerable<TEntity> entities);
        Task<IReadOnlyList<TEntity>> GetCachedList<TEntity>();
        Task InvalidateCache<TEntity>();
    }
}