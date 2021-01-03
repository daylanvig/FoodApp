using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests.Acceptance.FoodApp.TestHelpers
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Navigates to a relative url (from domain base)
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="url">The URL.</param>
        public static void NavigateTo(this IWebDriver driver, string url)
        {
            // baseURL includes the ending slash, but by convention is included
            if (url.StartsWith("/"))
            {
                url = url[1..];
            }
            driver.Navigate().GoToUrl($"{Config.BASE_URL}{url}");
        }

        /// <summary>
        /// Wait for element to exist on page, returning it when it does
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="by">The selector for the element</param>
        /// <param name="waitMS">Max wait time in ms, default is 3000</param>
        /// <returns></returns>
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int waitMS = 3000)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(waitMS));
            return wait.Until(d => d.FindElement(by));
        }

        /// <summary>
        /// Waits for a condition evaluate correctly
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="driver">The driver.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="waitMS">Max wait time in ms, default is 3000</param>
        /// <returns></returns>
        public static TResult WaitFor<TResult>(this IWebDriver driver, Func<IWebDriver, TResult> condition, int waitMS = 3000)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(waitMS));
            return wait.Until(condition);
        }
    }
}
