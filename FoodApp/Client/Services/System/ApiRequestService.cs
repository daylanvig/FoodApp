using FoodApp.Shared.AppProperties;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodApp.Client.Services.System
{
    public class ApiRequestService : IApiRequestService
    {
        private readonly HttpClient _client;
        private readonly IEntityCache _entityCache;

        public ApiRequestService(HttpClient client, IEntityCache entityCache)
        {
            _client = client;
            _entityCache = entityCache;
        }

        public Task<TEntity> GetById<TEntity>(int id)
        {
            var controller = EntityControllerMap.GetController<TEntity>();

            return _client.GetFromJsonAsync<TEntity>($"/{controller}/{id}");
        }

        public async Task<IReadOnlyList<TEntity>> GetList<TEntity>()
        {
            var cachedEntities = await _entityCache.GetCachedList<TEntity>();
            if(cachedEntities != null)
            {
                return cachedEntities;
            }
            var entities = await _client.GetFromJsonAsync<IReadOnlyList<TEntity>>($"/{EntityControllerMap.GetController<TEntity>()}/");
            await _entityCache.CacheList(entities);
            return entities;
        }

        public async Task<TEntity> Add<TEntity>(TEntity entity)
        {
            var result = await _client.PostAsJsonAsync($"/{EntityControllerMap.GetController<TEntity>()}/", entity);
            result.EnsureSuccessStatusCode();
            await _entityCache.InvalidateCache<TEntity>();
            return JsonSerializer.Deserialize<TEntity>(await result.Content.ReadAsStringAsync());
        }

        public async Task<TEntity> Edit<TEntity>(int id, TEntity entity)
        {
            var result = await _client.PutAsJsonAsync($"/{EntityControllerMap.GetController<TEntity>()}/{id}", entity);
            result.EnsureSuccessStatusCode();
            await _entityCache.InvalidateCache<TEntity>();
            return JsonSerializer.Deserialize<TEntity>(await result.Content.ReadAsStringAsync());
        }

        public async Task Delete<TEntity>(int id)
        {
            await _entityCache.InvalidateCache<TEntity>();
            await _client.DeleteAsync($"/{EntityControllerMap.GetController<TEntity>()}/{id}");
        }

        public Task<T> GetFromJsonAsync<T>(string url)
        {
            return _client.GetFromJsonAsync<T>(url);
        }

        public async Task<T> GetFromJsonOrNavigateAsync<T>(string url)
        {
            T result;
            try
            {
                result = await _client.GetFromJsonAsync<T>(url);
            }
            catch (AccessTokenNotAvailableException e)
            {
                result = default;
                e.Redirect();
            }

            return result;
        }

        public async Task PostJsonAsync<TModel>(string url, TModel model)
        {
            var result = await _client.PostAsJsonAsync<TModel>(url, model);
            result.EnsureSuccessStatusCode();
        }

        public async Task<TReturnType> PostJsonAsync<TModel, TReturnType>(string url, TModel model)
        {
            var result = await _client.PostAsJsonAsync<TModel>(url, model);
            result.EnsureSuccessStatusCode();
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TReturnType>(content);
        }
    }
}
