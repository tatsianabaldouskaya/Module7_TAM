Feature: SpecFlowCreateMessageTest
	As a user I want to create a message and save it as a draft

@critical_path
Background:
	Given I am logged in my account
Scenario Outline: Create message
	When I click composeButton
	And I enter '<addresseeValue>' to addresseeField
	And I enter '<subjectValue>' to subjectField
	And I enter '<bodyValue>' to bodyField 
	And I click closeIcon
	And I open drafts folder
	Then letter is displayed in drafts folder

	Examples:
	| addresseeValue           | subjectValue | bodyValue			|
	| tatiana95.77@gmail.com   |  For Test    | This is test email	|
	| tatiana95.77+1@gmail.com |  For Test2   | Hello world!		|
	| tatiana95.77+2@gmail.com |  For Test	  | It's my test project|