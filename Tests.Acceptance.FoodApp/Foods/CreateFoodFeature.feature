Feature: CreateFoodFeature

Scenario: Create Food - Green Path
	Given I am logged into my account
	And I navigate to the inventory page
	And I enter a description of "Pink Lady Apple"
	And I enter a quantity of 1
	And I select a quantity type of Items
	And I click Add New Food
	Then my inventory list should have "Pink Lady Apply" with a quantity of 1 item(s)
