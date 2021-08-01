Feature: SpecFlowDeleteByRightClickTest
	As a user I want rightclick the letter and delete it

Background:
	Given I am logged in my account	
	And I create new letter
	And I open drafts folder

@regression
Scenario: Right click the letter in drafts folder and click delete option
	When I do rightclick on the letter
	And I select delete option
	Then letter is deleted from the folder