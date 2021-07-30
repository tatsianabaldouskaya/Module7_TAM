Feature: SpecFlowInboxTests
	As a user
	I want to be able to delete letter by hover

@regression
Scenario: Hovering letter and clicking basket icon should delete the letter
	Given I am logged in my account
	And create new letter
	And open drafts folder
	When I hover the letter
	And click basket icon
	Then letter is deleted from the folder