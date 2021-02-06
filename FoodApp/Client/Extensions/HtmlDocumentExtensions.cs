using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Client.Extensions
{
    public static class HtmlDocumentExtensions
    {
        /// <summary>
        /// Parse document for header tags
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public static IList<HtmlNode> GetHeaders(this HtmlDocument document)
        {
            return document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
        }

        /// <summary>
        /// Get list elements from page
        /// </summary>
        /// <param name="document"></param>
        /// <returns>Nodes with tag ul, ol, or dl</returns>
        public static IList<HtmlNode> GetPageLists(this HtmlDocument document)
        {
            return document.QuerySelectorAll("ul, ol, dl");
        }
    }
}
