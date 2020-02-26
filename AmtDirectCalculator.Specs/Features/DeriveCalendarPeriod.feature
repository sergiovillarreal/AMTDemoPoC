Feature: DeriveCalendarPeriod
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CalendarPeriod
Scenario: Derive Calendar Period Success
	Given I have entered 02/2020 into the DeriveCalendarPeriod API end point
	When I post the data to API
	Then the result should be 2/2020 on the screen

Scenario: Derive Calendar Period passing null value
	Given I have entered null into the DeriveCalendarPeriod API end point
	When I post the data to API
	Then the exception message should be Exception of type 'System.NullReferenceException' was thrown. on the result

Scenario: Derive Calendar Period Passing Bad Month Format Period Value
	Given I have entered 003/2020 into the DeriveCalendarPeriod API end point
	When I post the data to API
	Then the exception message should be You are passing more than two characters for the month value your date string is: 003/2020 (Parameter 'Period') on the result
