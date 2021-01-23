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

        public ApiRequestService(HttpClient client)
        {
            _client = client;
        }

        public Task<TEntity> GetById<TEntity>(int id)
        {
            var controller = EntityControllerMap.GetController<TEntity>();

            return _client.GetFromJsonAsync<TEntity>($"/{controller}/{id}");
        }

        public Task<IReadOnlyList<TEntity>> GetList<TEntity>()
        {
            return _client.GetFromJsonAsync<IReadOnlyList<TEntity>>($"/{EntityControllerMap.GetController<TEntity>()}/");
        }

        public async Task<TEntity> Add<TEntity>(TEntity entity)
        {
            var result = await _client.PostAsJsonAsync($"/{EntityControllerMap.GetController<TEntity>()}/", entity);
            result.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<TEntity>(await result.Content.ReadAsStringAsync());
        }

        public async Task<TEntity> Edit<TEntity>(int id, TEntity entity)
        {
            var result = await _client.PutAsJsonAsync($"/{EntityControllerMap.GetController<TEntity>()}/{id}", entity);
            result.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<TEntity>(await result.Content.ReadAsStringAsync());
        }

        public Task Delete<TEntity>(int id)
        {
            return _client.DeleteAsync($"/{EntityControllerMap.GetController<TEntity>()}/{id}");
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
