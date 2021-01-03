using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
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
