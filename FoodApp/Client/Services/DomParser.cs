using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Client.Services
{
    /// <inheritdoc cref="IDomParser"/>
    /// <remarks>
    /// This module serves as a wrapper for the HtmlAgilityPackLibrary
    /// </remarks>
    /// <seealso cref="https://html-agility-pack.net/from-string"/>
    public class DomParser : IDomParser
    {
        public HtmlDocument ParseFromString(string htmlContent)
        {
            var document = new HtmlDocument();
            document.LoadHtml(htmlContent);
            return document;
        }

        public Task<HtmlDocument> ParseFromUrlAsync(string url)
        {
            var html = new HtmlWeb();
            return html.LoadFromWebAsync(url);
        }
    }
}
