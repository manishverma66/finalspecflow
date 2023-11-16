using finalspecflow.POM;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class guru99steps
    {
        pom Call = new pom();
        private IWebDriver driver;
        public static string Path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\TestResults");

        public guru99steps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Launch the chrome browser and open the url")]
        public void GivenLaunchTheChromeBrowserAndOpenTheUrl()
        {
            driver.Navigate().GoToUrl("https://www.demo.guru99.com/v4/index.php");
            Thread.Sleep(2000);
            
        }
        
        [Given(@"Enter a valid userid (.*) and password (.*)")]
        public void GivenEnterAValidUseridAndPassword(string emailid, string password)
        {
            Call.EnterEmail(emailid, password);
            Thread.Sleep(1000);
        }

        [When(@"Click on the login button")]
        public void WhenClickOnTheLoginButton()
        {
            Call.Loginguru99();
            Thread.Sleep(2000);
        }
                    


        [Then(@"User should bee sucessfully redirecteded to home page of application")]
        public void ThenUserShouldBeeSucessfullyRedirectededToHomePageOfApplication()
        {
            string pageTitle = driver.Title;
            Console.WriteLine("Page Title: " + pageTitle);
            string title = "Guru99 Bank Manager HomePage";
            Assert.AreEqual(title, pageTitle, "Page title doesn't match the expected title.");
            Console.WriteLine("Page Title is matched with the expected title of page ");
            Thread.Sleep(3000);
            string Manager = driver.FindElement(By.XPath("//td[normalize-space()='Manger Id : mngr522908']")).Text;
            Console.WriteLine("The text is: " + Manager);
            //Manger Id : mngr522908
            string[] split = Manager.Split(':');
            string managerId = split[1].Replace(" ", "");
            Console.WriteLine("Manager ID is:" +managerId);
            string Managerid = "mngr522908";
            Assert.AreEqual(managerId, Managerid, "Manager id is not matching.");
            Console.WriteLine("Manager iD is correctly matching with contents. ");
            Thread.Sleep(3000);
            //take screenshots
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            // Save the screenshot to a file Path1 + @"Flipkart.xlsx";
            string screenshotPath = Path1 + @"screenshot.png";
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            Console.WriteLine("Screenshot saved as: " + screenshotPath);
            driver.FindElement(By.XPath("//a[normalize-space()='Log out']")).Click();
            Thread.Sleep(3000);
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            Console.WriteLine("Alert Text: " + alertText);
            alert.Accept();
            Thread.Sleep(4000);
            driver.Close();

        }

    }
}
