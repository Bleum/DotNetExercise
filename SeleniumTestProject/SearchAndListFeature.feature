Feature: List
	The system lists item information on pages in the form. 3 items to a page.
	The user can search for an item based on "Employee Name" and/or "Job Title"

#Comment: For all Scenarios in this Feature the following table data exists
#| Employee Name    | Job Title |
#| John Smith       | Manager   |
#| John Jacob       | Developer |
#| Frank Smith      | Developer |
#| Susan Richardson | Manager   |
#| Polly Pickler    | Tester    |
#| Tommy Cruse      | Assistant |
#| Michael Munster  | Tester    |


@FormList
Scenario: Opening the list form
Given I am logged into the form page
When I have not pressed Search
Then the form lists 3 items on the page
And there are 3 pages total
And it displays
| Employee Name    | Job Title |
| John Smith       | Manager   |
| John Jacob       | Developer |
| Frank Smith      | Developer |

#UE test cases
#Given I am logged into the form page
#When there are more than 3 items to be displayed
#Then the link "next page" is avaliable

#Given I am logged into the form page
#When the form is not displaying the first 3 items of the data
#Then the link "previous page" is avaliable

Scenario: Next Page
Given I am logged into the form page
And the link "next page" is avaliable
When I click on "next page"
Then the form lists the next 3 items on the next page
And it displays
| Employee Name    | Job Title |
| Susan Richardson | Manager   |
| Polly Pickler    | Tester    |
| Tommy Cruse      | Assistant |

Scenario: Previous Page
Given I am logged into the form page
And the link "previous page" is avaliable
When I click on "previous page"
Then the form lists the previous 3 items on the previous page
And it displays
| Employee Name    | Job Title |
| John Smith       | Manager   |
| John Jacob       | Developer |
| Frank Smith      | Developer |

#_________________________________________________________



#Comment: For all Scenarios in this Feature the following table data exists
#| Employee Name    | Job Title |
#| John Smith       | Manager   |
#| John Jacob       | Developer |
#| Frank Smith      | Developer |
#| Susan Richardson | Manager   |
#| Polly Pickler    | Tester    |
#| Tommy Cruse      | Assistant |
#| Michael Munster  | Tester    |

@FormSearch

Scenario: Search by First Name
Given I am logged into the form page
When I enter "John" in the Search Name field
And press search
Then the table displays only
| Employee Name    | Job Title |
| John Smith       | Manager   |
| John Jacob       | Developer |

Scenario: Search by Last Name
Given I am logged into the form page
When I enter "Smith" in the Search Name field
And press search
Then the table displays only
#| Employee Name    | Job Title |
#| John Smith       | Manager   |
#| Frank Smith      | Developer |

Scenario: Search by First and Last Name
Given I am logged into the form page
When I enter "John Smith" in the Search Name field
And press search
Then the table displays only
| Employee Name    | Job Title |
| John Smith       | Manager   |

Scenario: Search by Job Title
Given I am logged into the form page
When I enter "Manager" in the Search Job field
And press search
Then the table displays only
| Employee Name    | Job Title |
| John Smith       | Manager   |
| Susan Richardson | Manager   |

Scenario: Search by Job Title (Multiple)
Given I am logged into the form page
When I enter "Manager Developer" in the Search Job field
And press search
Then the table displays only
| Employee Name    | Job Title |
| John Smith       | Manager   |
| John Jacob       | Developer |
| Frank Smith      | Developer |
| Susan Richardson | Manager   |

Scenario: Search by Name and Job Title
Given I am logged into the form page
When I enter "John" in the Search Name field 
And I enter "Manager" in the Search Job field
And press search
Then the table displays only
| Employee Name    | Job Title |
| John Smith       | Manager   |