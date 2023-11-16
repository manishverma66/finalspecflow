using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class amazonsteps
    {
        private IWebDriver driver;
        private List<string> allProducts = new List<string>();
        public static string Path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Results");

        public amazonsteps(IWebDriver driver)
        {
            this.driver = driver;
        }
       

        [Given(@"Launchh the browser in chrome")]
        public void GivenLaunchhTheBrowserInChrome()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            Thread.Sleep(4000);
        }
        
        [Given(@"Open thee amazon url in chromee")]
        public void GivenOpenTheeAmazonUrlInChromee()
        {
            driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']")).SendKeys("smartphones under 10000");
            driver.FindElement(By.XPath("//input[@id='nav-search-submit-button']")).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)", "");

        }

        [When(@"make the entry of phones save in excel sheet")]
        public void WhenMakeTheEntryOfPhonesSaveInExcelSheet()
        {
            for (int page = 1; page <= 4; page++)
            {
                Console.WriteLine($"Scraping products from page: {page}");
                List<string> products = new List<string>();

                IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.XPath("//span[@class='a-size-medium a-color-base a-text-normal']"));

                foreach (IWebElement p in productElements)
                {
                    products.Add(p.Text);
                }
                Console.WriteLine($"Total products scraped from page {page}: {products.Count}");
                Thread.Sleep(5000);

                foreach (string product in products)
                {
                    Console.WriteLine(product);
                    allProducts.Add(product);
                }

                Thread.Sleep(5000);

                Console.WriteLine($"Moving to next page of Amazon {page}");

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,1000)", "");

                IWebElement nextButton = driver.FindElement(By.XPath("//a[normalize-space()='Next']"));
                nextButton.Click();
                Thread.Sleep(2000);
            }

            //writing data in excel
            //String path = @"C:\Users\manish.verma\source\repos\finalspecflow\Results\amazon.xlsx";
            String path = Path1 + @"amazon.xlsx";
            using (XLUtility xlUtility = new XLUtility(path))
            {
                xlUtility.SetCellData("Sheet1", 1, 1, "Phones under 10000");

                Console.WriteLine("Writing data to Excel sheet.");

                for (int rowindex = 2; rowindex <= allProducts.Count + 1; rowindex++)
                {
                    xlUtility.SetCellData("Sheet1", rowindex, 1, allProducts[rowindex - 2]);
                }

                Console.WriteLine("Data has been written to the Excel sheet.");
            }
        }

    

    [Then(@"save the enrtyy in excel")]
        public void ThenSaveTheEnrtyyInExcel()
        {
            driver.Close();
            
        }
    }
}
