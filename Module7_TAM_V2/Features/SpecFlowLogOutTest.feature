Feature: SpecFlowLogInTest
	As a user I Want to log out from my email

@critical_path
Scenario: Log out from email
	Given I am logged in my account
	When I click user icon
	And I click Sign out button
	Then Signed out text is displayed