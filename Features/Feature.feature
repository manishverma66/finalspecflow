Feature: To test login functionality for OrangeHRm application
	To test login functionalitis 

@MHCLogin
@Launch MHC website and make login into application with users account
Scenario Outline: To make login in orange HRM application and go to home page
	Given Launch the browser and open the url
	And Enter the valid userid <emailid> and password <password>
	When Click on login button
	Then User should be sucessfully redirected to home page of application

	@source:MHC.xlsx:Sheet1
	Examples:
		| emailid | password |

@Launch web app and write data into excel
Scenario: To launch the url and save the data in excel
	Given Launchh the browser 
	And Open thee url in chromee
	When make the entry save in excel sheet
	Then save the enrtyy

	

@Launch Amazon web app and write data into excel
Scenario: To launch the Amazon url and save the data in excel
	Given Launchh the browser in chrome 
	And Open thee amazon url in chromee
	When make the entry of phones save in excel sheet
	Then save the enrtyy in excel

@Launch Flipkart web app and write data intoo excel
Scenario: To launch the Flipkart search product and save the data in excel
	Given Launchh the chrome browser. 
	And Open thee Flipkart url in chromee
	When Search for phones under 10000
	Then save the records in excel
	Then close the chrome browse.

@guru99
@Launch Guru99 website and make login into application with correct users account
Scenario Outline: To make login in Guru99 application and go to home page
	Given Launch the chrome browser and open the url
	And Enter a valid userid <emailid> and password <password>
	When Click on the login button
	Then User should bee sucessfully redirecteded to home page of application

	@source:MHC.xlsx:Sheet2
	Examples:
		| emailid | password |


@Admin
@Launch Admin pannel website and make login into application and export data in excel sheet
Scenario Outline: To make login in Adminportal application and save data in excel
	Given Launch the chrome browser and open the url for admin portal
	And Eneter a valid userid <emailid> and password <password> to make loginb
	When Click on the login button to login
	Then Save the data in exel sheet
	Then close tge opened bwowser

	@source:MHC.xlsx:Sheet3
	Examples:
		| emailid | password |



@Test(priority = 2)
@Launch petperasite web app and click on states
Scenario: To launch the petperasite app and click on relevent states
	Given Launchh the chrome browser for. 
	And Open thee petperasite website
	When go inside frame
	Then click on states
	Then close the chrome browse..


@amazoncamera
@Launch Amazon web application search for Camera and write results into excel
Scenario: To launch amazon web application search for Camera and write results into excel
	Given Launchh the browser in chrome browser 
	And Open thee amazon url in chromee browser
	When Type Camera in search box and click on search icon
	Then save the results in excel sheet or notepad
	Then Close the opened Browser



@Unstop
@Launch Unstop web application and do signup for candidate.
Scenario Outline: To make Signup for unstop web application
	Given Launch the chrome browser and open the url for unstop application
	And Click on the "Signup button" to redirect on sign up page.
	And Fill all the deatils for Signup page <FirstName> <LastName> <UserName> <Email> <password> <confirmpassword>
	Then Click on the "Next" button to complete the sign-up process.
	Then Close the browser after successfully signing up.

	@source:unstop.xlsx:Sheet1
	Examples:
		| FirstName | LastName | UserName | Email | password | confirmpassword |



  Scenario Outline: User login with valid credentials
    Given User is on the application login page apple
    When User enters apple "<Username>" and "<Password>"
    And User clicks the Login button apple
    Then User should be logged in successfully apple

    Examples:
      | Username   | Password  |
      | testuser1  | Pass123   |
      | Admin | admin123 |
	  | Adminn | admin1234 |









	 


