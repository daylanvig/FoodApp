using HtmlAgilityPack;
using System.Threading.Tasks;

namespace FoodApp.Client.Services
{
    /// <summary>
    /// DomParser - Wrapper to parse html content
    /// </summary>
    public interface IDomParser
    {
        /// <summary>
        /// Parse html string to html document
        /// </summary>
        /// <param name="htmlContent"></param>
        /// <returns></returns>
        HtmlDocument ParseFromString(string htmlContent);
        /// <summary>
        /// Parse html from provided url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<HtmlDocument> ParseFromUrlAsync(string url);
    }
}