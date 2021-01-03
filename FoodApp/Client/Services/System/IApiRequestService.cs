using System.Threading.Tasks;

namespace FoodApp.Client.Services.System
{
    public interface IApiRequestService
    {
        /// <summary>
        /// Gets from json asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<T> GetFromJsonAsync<T>(string url);
        /// <summary>
        /// Gets from json. If request fails due to login status, instead navigates to the redirected page.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        Task<T> GetFromJsonOrNavigateAsync<T>(string url);
        /// <summary>
        /// Posts the json asynchronous (no return type expected/needed)
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="model">The model.</param>
        /// <exception cref="System.Net.Http.HttpRequestException">Request not successful</exception>
        Task PostJsonAsync<TModel>(string url, TModel model);
        /// <summary>
        /// Posts the json asynchronous.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TReturnType">The type returned from the API</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="model">The model.</param>
        /// <exception cref="System.Net.Http.HttpRequestException">Request not successful</exception>
        /// <returns></returns>
        Task<TReturnType> PostJsonAsync<TModel, TReturnType>(string url, TModel model);
    }
}
