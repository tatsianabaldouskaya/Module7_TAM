Feature: SpecFlowLogOutTest
	As a user I Want to log out from my email

Background:
 	Given I am logged in my account
@smoke
Scenario: Log out from email
	When I click user icon
	And I click Sign out button
	Then Signed out text is displayed