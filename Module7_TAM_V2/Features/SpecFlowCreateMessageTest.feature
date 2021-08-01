Feature: SpecFlowCreateMessageTest
	As a user I want to create a message and save it as a draft

Background:
	Given I am logged in my account
@critical_path
Scenario Outline: Create message
	Given I click composeButton
	When I enter '<addresseeValue>' to addresseeField
	And I enter '<subjectValue>' to subjectField
	And I enter '<bodyValue>' to bodyField 
	And I click closeIcon
	And I open drafts folder
	Then letter is displayed in drafts folder

	Examples:
	| addresseeValue           | subjectValue | bodyValue |
	| tatiana95.77@gmail.com   | For test     |email_11c  |
	| tatiana95.77+1@gmail.com | For test     |email_25b  |
	| tatiana95.77+2@gmail.com | For test     |email_77a  |