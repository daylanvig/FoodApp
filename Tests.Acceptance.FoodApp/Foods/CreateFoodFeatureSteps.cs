using System;
using Tests.Acceptance.FoodApp.TestHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace Tests.Acceptance.FoodApp.Foods
{
    [Binding]
    public class CreateFoodFeatureSteps : FoodsStepsBase
    {
        [Given(@"I am logged into my account")]
        public void GivenIAmLoggedIntoMyAccount()
        {
            driver.NavigateTo("/authentication/login");
            var emaiInput = driver.WaitForElement(By.Id("Input_Email"));
            var passwordInput = driver.WaitForElement(By.Id("Input_Password"));
            emaiInput.SendKeys(Config.TEST_EMAIL);
            passwordInput.SendKeys(Config.TEST_PASSWORD);
            driver.WaitForElement(By.Id("login-submit")).Click();
            driver.WaitFor(d => d.Url == Config.BASE_URL);
        }
        
        [Given(@"I navigate to the inventory page")]
        public void GivenINavigateToTheInventoryPage()
        {
            driver.NavigateTo("/Inventory");
        }
        
        [Given(@"I enter a description of ""(.*)""")]
        public void GivenIEnterADescriptionOf(string p0)
        {
            driver.WaitForElement(By.Name("Food.Name")).SendKeys(p0);
        }
        
        [Given(@"I enter a quantity of (.*)")]
        public void GivenIEnterAQuantityOf(int p0)
        {
            driver.WaitForElement(By.Name("Food.AmountOnHand")).SendKeys(p0.ToString());
        }
        
        [Given(@"I select a quantity type of Items")]
        public void GivenISelectAQuantityTypeOfItems()
        {
            driver.WaitForElement(By.Name("Food.AmountOnHand")).SendKeys("Items");
        }
        
        [Then(@"my inventory list should have ""(.*)"" with a quantity of (.*) item\(s\)")]
        public void ThenMyInventoryListShouldHaveWithAQuantityOfItemS(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
