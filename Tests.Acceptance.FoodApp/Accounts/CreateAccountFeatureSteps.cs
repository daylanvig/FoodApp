using System;
using TechTalk.SpecFlow;

namespace Tests.Acceptance.FoodApp.Accounts
{
    [Binding]
    public class CreateAccountFeatureSteps : AccountsStepsBase
    {
        [Given(@"I am not signed in")]
        public void GivenIAmNotSignedIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I am on the authentication/register page")]
        public void GivenIAmOnTheAuthenticationRegisterPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter an email address of ""(.*)""")]
        public void GivenIEnterAnEmailAddressOf(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter a password of ""(.*)""")]
        public void GivenIEnterAPasswordOf(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter a confirm password of ""(.*)""")]
        public void GivenIEnterAConfirmPasswordOf(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I navigate to the authentication page")]
        public void WhenINavigateToTheAuthenticationPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I submit the registration form")]
        public void WhenISubmitTheRegistrationForm()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the browser title should be '(.*)'")]
        public void ThenTheBrowserTitleShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"there should be an account in the database with the email ""(.*)""")]
        public void ThenThereShouldBeAnAccountInTheDatabaseWithTheEmail(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should be redirected to the login page with the email spot filled out with ""(.*)""")]
        public void ThenIShouldBeRedirectedToTheLoginPageWithTheEmailSpotFilledOutWith(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"there exists an account with the email address ""(.*)""")]
        public void GivenThereExistsAnAccountWithTheEmailAddress(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"An error should be displayed that registration was unsuccessful due to an existing account")]
        public void ThenAnErrorShouldBeDisplayedThatRegistrationWasUnsuccessfulDueToAnExistingAccount()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
