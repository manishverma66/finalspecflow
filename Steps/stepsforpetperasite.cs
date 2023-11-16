using OpenQA.Selenium;

using System;
using System.Threading;
using TechTalk.SpecFlow;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace finalspecflow.Steps
{
    [Binding]
    public class stepsforpetperasite
    {
        private IWebDriver driver;
        //String Baseurl = "https://petdiseasealerts.org/forecast-map";
        String Baseurl = "https://selectorshub.com/xpath-practice-page/";



        public stepsforpetperasite(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Launchh the chrome browser for\.")]
        public void GivenLaunchhTheChromeBrowserFor_()
        {
            driver.Navigate().GoToUrl(Baseurl);
            Thread.Sleep(3000);
        }
        
        [Given(@"Open thee petperasite website")]
        public void GivenOpenTheePetperasiteWebsite()
        {
            driver.Navigate().GoToUrl("https://demo.automationtesting.in/Frames.html");
            driver.FindElement(By.XPath("//a[normalize-space()='Iframe with in an Iframe']")).Click();

            // Switch to the first iframe
            IWebElement iframe1 = driver.FindElement(By.XPath("//iframe[@src='MultipleFrames.html']"));
            driver.SwitchTo().Frame(iframe1);

            // Switch to the second iframe inside the first iframe
            IWebElement iframe2 = driver.FindElement(By.XPath("//iframe[normalize-space()='<p>Your browser does not support iframes.</p>']"));
            driver.SwitchTo().Frame(iframe2);

            // Find the input element inside the second iframe and send keys
            IWebElement inputInFrame3 = driver.FindElement(By.XPath("//input[@type='text']"));
            inputInFrame3.SendKeys("Value for frame2");

            // Switch back to the default content if needed
            driver.SwitchTo().DefaultContent();
      

            //driver.FindElement(By.XPath("//div[@class='element-companyId'] //input[@name='company']")).SendKeys("Nathcorp");
            Thread.Sleep(9000);
            //This Element is inside single shadow DOM.
            String cssSelectorForHost1 = "#userName";
            Thread.Sleep(1000);
            ISearchContext shadow = driver.FindElement(By.CssSelector("#userName")).GetShadowRoot();
            Thread.Sleep(1000);
            shadow.FindElement(By.CssSelector("#kils"));
            driver.FindElement(By.XPath("//div[@id='userName']")).Click();
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Tab).Perform();
            actions.SendKeys("123456").Perform();
            //driver.FindElement(By.XPath("//div[@id='userPass']")).Click();
            //Actions actions = new Actions(driver);
            //actions.SendKeys(Keys.Tab).Perform();
            //actions.SendKeys("123456").Perform();



            //driver.FindElement(By.XPath("//div[@class='element-companyId']//input[@placeholder='Enter your mobile number']")).SendKeys("8969565073");
            //Thread.Sleep(3000);
            ////selenium code to enable a diabled elemnet and entet text
            //IWebElement inputElement = driver.FindElement(By.XPath("//input[@placeholder='First Enter name']"));
            //// Enable the disabled input box using JavaScript
            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            //jsExecutor.ExecuteScript("arguments[0].removeAttribute('disabled');", inputElement);
            //inputElement.SendKeys("Manish");
            //Thread.Sleep(3000);
            ////code to enter last name
            //IWebElement inputElementt = driver.FindElement(By.XPath("//input[@placeholder='Enter Last name']"));
            //// Enable the disabled input box using JavaScript
            //IJavaScriptExecutor jsExecutorrr = (IJavaScriptExecutor)driver;
            //jsExecutor.ExecuteScript("arguments[0].removeAttribute('disabled');", inputElementt);
            //inputElementt.SendKeys("Manish");
            //code to use action class
            //Actions actions = new Actions(driver);
            //IWebElement elementToHover = driver.FindElement(By.XPath("//button[@class='dropbtn']"));
            //actions.MoveToElement(elementToHover).Perform();
            //Thread.Sleep(3000);
            //IWebElement subMenuOption = driver.FindElement(By.XPath("//a[normalize-space()='Try TestCase Studio']")); 
            //subMenuOption.Click();



        }

        [When(@"go inside frame")]
        public void WhenGoInsideFrame()
        {
           
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(driver => driver.FindElements(By.TagName("iframe")).Count > 0);
            //driver.SwitchTo().Frame(0);

            //IWebElement elementInsideIframe = driver.FindElement(By.XPath("//*[name()='path' and @id='region-5']"));
            //elementInsideIframe.Click();
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//a[normalize-space()='United States']")).Click();
            //Thread.Sleep(3000);

            ////next elemnet click

            //WebDriverWait iframeWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //iframeWait.Until(driver => driver.FindElement(By.XPath("//*[name()='path' and @id='region-10']")).Displayed);
            //IWebElement elementInsideIframee = driver.FindElement(By.XPath("//*[name()='path' and @id='region-10']"));

            //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            //jsExecutor.ExecuteScript("arguments[0].dispatchEvent(new Event('click'));", elementInsideIframee);
            //Thread.Sleep(3000);


            //driver.FindElement(By.XPath("//a[normalize-space()='United States']")).Click();
            Thread.Sleep(2000);





            //// After interacting with elements inside the iframe, you may want to switch back to the main page
            //driver.SwitchTo().DefaultContent();

        }
        
        [Then(@"click on states")]
        public void ThenClickOnStates()
        {
            Console.WriteLine($"clicked");
        }
        
        [Then(@"close the chrome browse\.\.")]
        public void ThenCloseTheChromeBrowse_()
        {
            driver.Close();
        }
    }
}
