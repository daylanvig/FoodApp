using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FoodApp.Client.Services.System
{
    public interface IApiRequestService
    {
        Task<T> GetFromJsonAsync<T>(string url);
    }

    public class ApiRequestService : IApiRequestService
    {
        private readonly HttpClient _client;

        public ApiRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetFromJsonAsync<T>(string url)
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
    }
}
