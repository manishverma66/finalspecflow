using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class Flipkartsteps
    {
        private IWebDriver driver;
        private List<string> allProducts = new List<string>();
        private List<string> allprices = new List<string>();
        private List<string> allratings = new List<string>();
        public static string Path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Results");

        public Flipkartsteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Launchh the chrome browser\.")]
        public void GivenLaunchhTheChromeBrowser_()
        {
            driver.Navigate().GoToUrl("https://www.flipkart.com/");
            Thread.Sleep(3000);
        }

        [Given(@"Open thee Flipkart url in chromee")]
        public void GivenOpenTheeFlipkartUrlInChromee()
        {
            //for (int i = 0; i < 10; i++) // Try for a maximum of 10 seconds
            //{
            //    try
            //    {
            //        IWebElement closeButton = driver.FindElement(By.XPath("//button[@class='_2KpZ6l _2doB4z']"));
            //        if (closeButton.Displayed)
            //        {
            //            closeButton.Click();
            //            break; // Exit the loop if the pop-up was closed
            //        }
            //    }

            //    catch (NoSuchElementException e)
            //{
            //    Console.WriteLine($"exception is: {e}");
            //}

            //}
            Thread.Sleep(3000);
        }

        [When(@"Search for phones under (.*)")]
        public void WhenSearchForPhonesUnder(int p0)
        {
            //driver.FindElement(By.XPath("//input[@title='Search for Products, Brands and More']")).SendKeys("smartphones under 10000");

            IWebElement searchInput = driver.FindElement(By.XPath("//input[@title='Search for Products, Brands and More']"));
            searchInput.SendKeys("smartphones under 10000");
            searchInput.SendKeys(Keys.Enter);
            Thread.Sleep(3000);




        }

        [Then(@"save the records in excel")]
        public void ThenSaveTheRecordsInExcel()
        {
            //String path = @"C:\Users\manish.verma\source\repos\finalspecflow\Results\Flipkart.xlsx";
            String path = Path1 + @"Flipkart.xlsx";

            // Scraping product names
            for (int page = 1; page <= 3; page++)
            {
                
                Console.WriteLine($"Scraping phones names from page: {page}");

                List<string> products = new List<string>();

                IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.XPath("//div[@class='_4rR01T']"));

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

                // Scraping product prices
                //Console.WriteLine($"Moving to next page of Flipkart: {page}");
                Console.WriteLine($"Scraping phones prices from page: {page}");
                List<string> prices = new List<string>();

                IReadOnlyCollection<IWebElement> productPrices = driver.FindElements(By.XPath("//div[@class='_30jeq3 _1_WHN1']"));

                foreach (IWebElement p in productPrices)
                {
                    prices.Add(p.Text);
                }

                Console.WriteLine($"Total products prices scraped from page {page}: {prices.Count}");
                Thread.Sleep(5000);

                foreach (string price in prices)
                {
                    Console.WriteLine(price);
                    allprices.Add(price);
                }

                //scraping products rating
                //Console.WriteLine($"Moving to next page of Flipkart: {page}");
                Console.WriteLine($"Scraping phones Ratings from page: {page}");

                List<string> ratings = new List<string>();
                IWebElement parentDiv = driver.FindElement(By.XPath("//div[@class='_1YokD2 _3Mn1Gg']"));

                // Find all child div elements under the parent
                IReadOnlyCollection<IWebElement> productrating = parentDiv.FindElements(By.XPath(".//div[@class='_3LWZlK']"));

                //IWebElement table = driver.FindElement(By.XPath("//div[@class='_1YokD2 _3Mn1Gg'] //div[@class='_3LWZlK']"));
                //IReadOnlyCollection<IWebElement> productrating = driver.FindElements(By.XPath("//div[@class='_1YokD2 _3Mn1Gg'] //div[@class='_3LWZlK']"));

                foreach (IWebElement p in productrating)
                {
                    ratings.Add(p.Text);
                }

                Console.WriteLine($"Total ratings scraped from page {page}: {ratings.Count}");
                Thread.Sleep(5000);

                foreach (string rating in ratings)
                {
                    Console.WriteLine(rating);
                    allratings.Add(rating);
                }

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,1000)", "");
                Thread.Sleep(3000);

                IWebElement nextButton = driver.FindElement(By.XPath("//span[normalize-space()='Next']"));
                nextButton.Click();
                Thread.Sleep(2000);
            }

            // Writing data to Excel
            using (XLUtility xlUtility = new XLUtility(path))
            {
                xlUtility.SetCellData("Sheet1", 1, 1, "********Phones under 10000***********");
                xlUtility.SetCellData("Sheet1", 1, 2, "Prices");
                xlUtility.SetCellData("Sheet1", 1, 3, "Ratings");

                Console.WriteLine("Writing data to Excel sheet.");

                for (int rowindex = 2; rowindex <= allProducts.Count + 1; rowindex++)
                {
                    xlUtility.SetCellData("Sheet1", rowindex, 1, allProducts[rowindex - 2]);
                }

                for (int rowindex = 2; rowindex <= allprices.Count + 1; rowindex++)
                {
                    xlUtility.SetCellData("Sheet1", rowindex, 2, allprices[rowindex - 2]);
                }

                for (int rowindex = 2; rowindex <= allratings.Count + 1; rowindex++)
                {
                    xlUtility.SetCellData("Sheet1", rowindex, 3, allratings[rowindex - 2]);
                }

                Console.WriteLine("Data has been written to the Excel sheet.");
            }

        }
        
        [Then(@"close the chrome browse\.")]
        public void ThenCloseTheChromeBrowse_()
        {
            Console.WriteLine("web scrapping done sucessfully");
            driver.Close();
        }
    }
}
