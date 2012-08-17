Feature: Login Feature
	The system should allow user to login with valid user name and password.
	Incorrect user name or password will be prompt to try again.

@SuccessfulCases
Scenario: LoginCorrect
	Given I have entered "test" into the Username field
	And I have entered "testtest" into the Password field     
	When I press Login
	Then the system will allow me to login
	And take me to the Form
	
@FailingCases
Scenario: LoginWrongPassword
	Given I have entered "test" into the Username field
	And I have entered incorrectly "1111" into the Password field
	When I press Login
	Then the system will deny me from login

Scenario: LoginWrongUsername
	Given I have entered incorrectly "loisxie" into the Username field
	And I have entered "testtest" into the Password field
	When I press Login
	Then the system will deny me from login


