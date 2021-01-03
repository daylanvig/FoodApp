using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.FoodApp.TestHelpers
{
    public class StepsBase : IDisposable
    {
        protected IWebDriver driver;

        [BeforeScenario]
        public void PrepareScenario()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(Path.Join(Config.BASE_DIRECTORY, "TestHelpers"));
            }
        }

        public void Dispose()
        {
            driver.Dispose();
            driver = null;
            GC.SuppressFinalize(this);
        }
    }
}
