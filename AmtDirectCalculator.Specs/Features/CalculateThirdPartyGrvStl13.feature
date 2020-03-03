Feature: Calculate Third Party GRV STL 13
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CalculateThirdPartyGrvStl13
Scenario: Success
	Given I have entered the following values to the API endpoint
    | PVofGuaranteedRV | RateImplicit | NetInvLeaseSTL | CuUnearnedIntThirdPartyGrvStl |
    | 1012.2323M       | 2.4332M      | 983.234M       | 183M                          |
	When I post the data to CalculateThirdPartyGrvStl13 endPoint
	Then the result should be 
    | ThirdPartyGrvStl | NetThirdPartyGrvStl | UnearnedIntThirdPartyGrvStl | NetInvestmentInLeaseStl |
    | 1012.23M         | 1014.13M            | 184.89M                     | 983.23M                 |

Scenario: Sending null object
	Given I have entered null object into the CalculateThirdPartyGrvStl13 API endpoint
	When I post the data to CalculateThirdPartyGrvStl13 endPoint
	Then the result should be 
    | ThirdPartyGrvStl | NetThirdPartyGrvStl | UnearnedIntThirdPartyGrvStl | NetInvestmentInLeaseStl |
    | 0.0M         	   | 0.0M            	 | 0.0M                 	   | 0.0M                 	 |
