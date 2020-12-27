using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.FoodApp.Accounts
{
    public class AccountsStepsBase : IDisposable
    {
        protected IWebDriver driver;

        [BeforeScenario]
        public void PrepareDatabase()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
        }

        protected void EnterLoginDetails(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            driver.Dispose();
            driver = null;
        }
    }
}
