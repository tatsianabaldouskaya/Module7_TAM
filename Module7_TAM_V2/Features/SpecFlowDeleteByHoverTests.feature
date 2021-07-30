Feature: SpecFlowDeleteByHoverTests
	As a user
	I want to be able to delete letter by hover

@regression
Scenario: Hovering letter and clicking basket icon should delete the letter
	Given I am logged in my account
	And I create new letter
	And I open drafts folder
	When I hover the letter
	And I click basket icon
	Then letter is deleted from the folder