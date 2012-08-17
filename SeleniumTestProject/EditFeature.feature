Feature: EditandSave
         The system allows the user to edit Employee information and save it.

#Comment: For all Scenarios in this Feature the following table data exists
#| Employee Name    | Job Title |
#| John Smith       | Manager   |
#| John Jacob       | Developer |
#| Frank Smith      | Developer |
#| Susan Richardson | Manager   |
#| Polly Pickler    | Tester    |
#| Tommy Cruse      | Assistant |
#| Michael Munster  | Tester    |

@FormEditSave

Scenario: Edit Employee information "Employee Name"
Given I am logged into the form page
When I click Edit for item "Polly Picker"
Then the system opens the item on a new page
And the new page allows "Employee Name" and "Job Title" to be edited
And I enter the Employee Name as "Polly Cruse"

Scenario: Edit Employee information "Job Title"
Given I am logged into the form page
When I click "Edit" for item "Polly Picker
Then the system opens the item on a new page
And the new page allows "Employee Name" and "Job Title" to be edited
And I enter the Job Title to be "SQA"

Scenario: Save Edited Employee Information 
Given I have edited the Employee Name "Polly Pickler" to Polly Cruse"
And I have edited the Employee Job Title "Tester" to SQA"
When I click "Save" for item "Polly Pickler"
Then the system saves the changes
And the page will go to the form home page
And the data table will appear like this.
| Employee Name    | Job Title |
| John Smith       | Manager   |
| John Jacob       | Developer |
| Frank Smith      | Developer |
| Susan Richardson | Manager   |
| Polly Cruse      | Tester    |
| Tommy Cruse      | Assistant |
| Michael Munster  | Tester    |
