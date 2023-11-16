using finalspecflow.POM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class exampleofkeyworddriven
    {
        pom Call = new pom();
        
        private IWebDriver driver;
        public exampleofkeyworddriven(IWebDriver driver)
        {
            this.driver = driver;
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        [Given(@"User is on the application login page apple")]
        public void GivenUserIsOnTheApplicationLoginPageApple()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            //Thread.Sleep(2000);
        }
        
        [When(@"User enters apple ""(.*)"" and ""(.*)""")]
        public void WhenUserEntersAppleAnd(string Username, string Password)
        {
            Call.orangehrmlogin(Username, Password);
            //Thread.Sleep(2000);
        }
        
        [When(@"User clicks the Login button apple")]
        public void WhenUserClicksTheLoginButtonApple()
        {
            Thread.Sleep(2000);
        }
        
        [Then(@"User should be logged in successfully apple")]
        public void ThenUserShouldBeLoggedInSuccessfullyApple()
        {
            string validation = "//h6[normalize-space()='Dashboard']";
            bool isDashboardPresent = driver.FindElements(By.XPath(validation)).Count > 0;
            Assert.IsTrue(isDashboardPresent, "Dashboard element is not present.");

            string expectedText = "Dashboard";
            string xpathExpression = "//h6[normalize-space()='Dashboard']";
            IWebElement element = driver.FindElement(By.XPath(xpathExpression));

            // Get the actual text from the element
            string actualText = element.Text;

            // Use Assert.AreEqual to compare the actual text with the expected text
            Assert.AreEqual(expectedText, actualText);

           //driver.Close();
           
        }
    }
}
