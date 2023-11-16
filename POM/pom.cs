using finalspecflow.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace finalspecflow.POM
{
    class pom
    {
        //private IWebDriver driver;
        

        public void clickLogin()
        {
            string login = "//a[normalize-space()='Login']";
            Hooks1.driver.FindElement(By.XPath(login)).Click();
            Thread.Sleep(5000);
        }
        
        
            public void MHClogin(string emailid, string password)  //| emailid | password |
            {

            Hooks1.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string enteremailid = "//input[@placeholder='youremail@example.com']";
            IWebElement emailInput = Hooks1.driver.FindElement(By.XPath(enteremailid));
            emailInput.SendKeys(emailid);

            // Set an implicit wait to wait for elements to become clickable
           string passwordd = "//input[@placeholder='Password']";
            IWebElement passwordInput = Hooks1.driver.FindElement(By.XPath(passwordd));
            passwordInput.SendKeys(password);
           


        }


        public void EnterEmail(string emailid, string password)  //| emailid | password |
        {
            string enteremailid = "//input[@name='uid']";
            Hooks1.driver.FindElement(By.XPath(enteremailid)).SendKeys(emailid);
            Thread.Sleep(2000);
            string passwordd = "//input[@name='password']";
            Hooks1.driver.FindElement(By.XPath(passwordd)).SendKeys(password);
            Thread.Sleep(2000);

        }

        public void login()
        {

            Hooks1.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string login = "//input[@name='btn-submit']";
            Hooks1.driver.FindElement(By.XPath(login)).Click();
            
        }

        public void Loginguru99()
        {
            string login = "//input[@type='submit']";
            Hooks1.driver.FindElement(By.XPath(login)).Click();
            //Thread.Sleep(5000);
        }

        public void enterEmailforadminportal(string emailid, string password)  //| emailid | password |
        {
            string enteremailid = "//input[@id='username']";
            Hooks1.driver.FindElement(By.XPath(enteremailid)).SendKeys(emailid);
            Thread.Sleep(1000);
            string passwordd = "//input[@id='login']";
            Hooks1.driver.FindElement(By.XPath(passwordd)).SendKeys(password);
            Thread.Sleep(1000);


        }

        public void signupforupstop(string FirstName, string LastName, string UserName, string Email, string password, string confirmpassword)  //| emailid | password |
        {

            string[] inputFields = { "first_name", "last_name", "username", "email_address", "choose_password" };
            string[] inputValues = { FirstName, LastName, UserName, Email, password };

            for (int i = 0; i < inputFields.Length; i++)
            {
                string xpath = $"//input[@id='{inputFields[i]}']";
                IWebElement element = Hooks1.driver.FindElement(By.XPath(xpath));
                Actions actions = new Actions(Hooks1.driver);
                actions.MoveToElement(element).DoubleClick().SendKeys(inputValues[i]).Build().Perform();
                Thread.Sleep(2000);
            }

            string phoneXpath = "(//input[@id='mat-input-0'])[1]";
            IWebElement phoneElement = Hooks1.driver.FindElement(By.XPath(phoneXpath));
            Actions phoneActions = new Actions(Hooks1.driver);
            phoneActions.MoveToElement(phoneElement).DoubleClick().SendKeys("8969565073").Build().Perform();
            Thread.Sleep(2000);


            string confirmpassxpath = "//input[@id='confirm_password']";
            IWebElement confumpass = Hooks1.driver.FindElement(By.XPath(confirmpassxpath));
            Hooks1.driver.FindElement(By.XPath("//label[normalize-space()='Confirm Password']")).Click();
            Actions ob6 = new Actions(Hooks1.driver);
            ob6.MoveToElement(confumpass).DoubleClick().SendKeys(confirmpassword).Build().Perform();
            Thread.Sleep(2000);
        }

        public void orangehrmlogin(string username, string password)  //| emailid | password |
        {
            Hooks1.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string enteremailid = "//input[@placeholder='Username']";
            Hooks1.driver.FindElement(By.XPath(enteremailid)).SendKeys(username);
            
            string passwordd = "//input[@placeholder='Password']";
            Hooks1.driver.FindElement(By.XPath(passwordd)).SendKeys(password);
          
            string login = "//button[normalize-space()='Login']";
            Hooks1.driver.FindElement(By.XPath(login)).Click();


        }


    }
}
