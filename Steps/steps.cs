using finalspecflow.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class ToTestLoginFunctionalityForOrangeHRmApplicationSteps
    {
        pom Call = new pom();
        private IWebDriver driver;
        private WebDriverWait wait;
        public ToTestLoginFunctionalityForOrangeHRmApplicationSteps(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


        [Given(@"Launch the browser and open the url")]
        public void GivenLaunchTheBrowserAndOpenTheUrl()
        {
            driver.Navigate().GoToUrl("https://melanatedhealthqa.web.app/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Thread.Sleep(2000);
         
            Call.clickLogin();
           
        }
        
        [Given(@"Enter the valid userid (.*) and password(.*)")]
        public void GivenEnterTheValidUseridAndPassword(string emailid, string password)
        {
            Call.MHClogin(emailid, password);
            Thread.Sleep(3000);
        }
        
        [When(@"Click on login button")]
        public void WhenClickOnLoginButton()
        {
            //Call.login();
            Thread.Sleep(3000);
        }
        
        [Then(@"User should be sucessfully redirected to home page of application")]
        public void ThenUserShouldBeSucessfullyRedirectedToHomePageOfApplication()
        {
             // Replace with the appropriate selector
            Console.WriteLine("Welcome to the home page");
            //driver.Close();
        }
    }
}
