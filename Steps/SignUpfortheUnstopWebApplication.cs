using finalspecflow.POM;

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class SignUpfortheUnstopWebApplication
    {
        private IWebDriver driver;
        public SignUpfortheUnstopWebApplication(IWebDriver driver)
        {
            this.driver = driver;
        }
        pom Call = new pom();

        [Given(@"Launch the chrome browser and open the url for unstop application")]
        public void GivenLaunchTheChromeBrowserAndOpenTheUrlForUnstopApplication()
        {

            Thread.Sleep(10000);
            driver.FindElement(By.XPath("(//div[normalize-space()='Ok, Continue'])[1]")).Click();
            Thread.Sleep(3000);
        }

        [Given(@"Click on the ""(.*)"" to redirect on sign up page\.")]
        public void GivenClickOnTheToRedirectOnSignUpPage_(string buttonLabel)
        {
            IWebElement element = driver.FindElement(By.XPath("//span[normalize-space()='Sign up']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();

            Thread.Sleep(3000);
            //driver.FindElement(By.XPath("(//input[@id='user_category0'])[1]")).SendKeys("Manish");

        }

        [Given(@"Fill all the deatils for Signup page (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void GivenFillAllTheDeatilsForSignupPage(string FirstName, string LastName, string UserName, string Email, string password, string confirmpassword)
        {
            IWebElement element = driver.FindElement(By.XPath("//input[@id='confirm_password']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Call.signupforupstop(FirstName, LastName, UserName, Email, password, confirmpassword);
            Thread.Sleep(3000);
        }

        [Then(@"Click on the ""(.*)"" button to complete the sign-up process\.")]
        public void ThenClickOnTheButtonToCompleteTheSign_UpProcess_(string p0)
        {
            driver.FindElement(By.XPath("//label[contains(text(),'All your information is collected, stored and proc')]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[normalize-space()='Next']")).Click();
            Thread.Sleep(5000);

        }

        [Then(@"Close the browser after successfully signing up\.")]
        public void ThenCloseTheBrowserAfterSuccessfullySigningUp_()
        {
            driver.Close();
        }
    }
}
