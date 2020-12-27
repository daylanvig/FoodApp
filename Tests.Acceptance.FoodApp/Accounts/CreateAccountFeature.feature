Feature: CreateAccountFeature
			In order to use the application with private functionality
			I want to register for a new account

Scenario: Registration - Green Path
	Given I am on the authentication/register page
	And I enter an email address of "testnewemailaddress@mail.com"
	And I enter a password of "Password123"
	And I enter a confirm password of "Password123"
	When I submit the registration form
	Then there should be an account in the database with the email "testnewemailaddress@mail.com"
	And I should be redirected to the login page with the email spot filled out with "testnewemailaddress@mail.com"

Scenario: Registration - Red Path
	Given I am on the authentication/register page
	And there exists an account with the email address "existingemail@mail.com"
	And I enter an email address of "existingemail@mail.com"
	And I enter a password of "Password123"
	And I enter a confirm password of "Password123"
	When I submit the registration form
	Then An error should be displayed that registration was unsuccessful due to an existing account