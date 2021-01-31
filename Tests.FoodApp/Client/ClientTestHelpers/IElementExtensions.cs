using AngleSharp.Dom;
using Bunit;
using System;

namespace Tests.FoodApp.Client.ClientTestHelpers
{
    public static class IElementExtensions
    {
        /// <summary>
        /// Click element, catching the exception that was thrown
        /// </summary>
        /// <remarks>
        /// Exception is thrown by api in shared cases (when delete/add/edit fails for example), this allows for catch + retrieval
        /// </remarks>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Exception ClickAndCatch(this IElement element)
        {
            Exception ex = null;
            try
            {
                element.Click();
            }
            catch (Exception e)
            {
                ex = e;
            }
            return ex;
        }
    }
}
