using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Services.System
{
    // future -> this could be handled by PWA, check for blazor libraries
    public class EntityCache : IEntityCache
    {
        private const int CACHE_MINUTES = 60;
        private record CacheItem<TEntity>(IEnumerable<TEntity> Entities, DateTime StoredAt);

        private readonly ILocalStorageService _localStorage;

        public EntityCache(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }


        private static string GetCacheKey(Type t) => t.AssemblyQualifiedName;

        public async Task InvalidateCache<TEntity>()
        {
            await _localStorage.RemoveItemAsync(GetCacheKey(typeof(TEntity)));
        }

        public async Task CacheList<TEntity>(IEnumerable<TEntity> entities)
        {
            await _localStorage.SetItemAsync(GetCacheKey(typeof(TEntity)), new CacheItem<TEntity>(entities, DateTime.Now));
        }
        
        public async Task<IReadOnlyList<TEntity>> GetCachedList<TEntity>()
        {
            var cacheItem = await _localStorage.GetItemAsync<CacheItem<TEntity>>(GetCacheKey(typeof(TEntity)));
            if (cacheItem != null && cacheItem.StoredAt.AddMinutes(CACHE_MINUTES) >= DateTime.Now)
            {
                return cacheItem.Entities.ToList();
            }
            return null;
        }
    }
}
