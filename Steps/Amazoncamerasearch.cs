using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class Amazoncamerasearch
    {
        private IWebDriver driver;
        private List<string> allProducts = new List<string>();
        private List<string> allPrices = new List<string>();
        public static string Path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Results");
        public Amazoncamerasearch(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Launchh the browser in chrome browser")]
        public void GivenLaunchhTheBrowserInChromeBrowser()
        {
            Console.WriteLine($"Launching the chrome browser to perform the operations");


        }

        [Given(@"Open thee amazon url in chromee browser")]
        public void GivenOpenTheeAmazonUrlInChromeeBrowser()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            Thread.Sleep(3000);
        }

        [When(@"Type Camera in search box and click on search icon")]
        public void WhenTypeCameraInSearchBoxAndClickOnSearchIcon()
        {
            driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']")).SendKeys("Camera");
            Thread.Sleep(5000);          ////using wait as Thread.sleep so that you can see the execution flow.
            driver.FindElement(By.XPath("//input[@id='nav-search-submit-button']")).Click();
            Thread.Sleep(7000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,2000)", "");
        }

        [Then(@"save the results in excel sheet or notepad")]
        public void ThenSaveTheResultsInExcelSheetOrNotepad()
        {
            for (int page = 1; page <= 1; page++)
            {
                Console.WriteLine($"Scraping products from page: {page}");
                List<string> products = new List<string>();
                List<string> Prices = new List<string>();

                IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.XPath("//span[@class='a-size-medium a-color-base a-text-normal']"));
                IReadOnlyCollection<IWebElement> productprices = driver.FindElements(By.XPath("//span[@class='a-price-whole']"));
                foreach (IWebElement p in productElements)
                {
                    products.Add(p.Text);
                }
                foreach (IWebElement p in productprices)
                {
                    Prices.Add(p.Text);
                }

                Console.WriteLine($"Total products scraped from page {page}: {products.Count}");
                Console.WriteLine($"Total Prices scraped from page {page}: {Prices.Count}");
                Thread.Sleep(5000);

                foreach (string product in products)
                {
                    Console.WriteLine(product);
                    allProducts.Add(product);
                }
                foreach (string Price in Prices)
                {
                    Console.WriteLine(Price);
                    allPrices.Add(Price);
                }

                Thread.Sleep(5000);
            }
            //writing data in excel
            //String path = @"C:\Users\manish.verma\source\repos\finalspecflow\Results\AmazonCamera.xlsx";
            string path = Path1 + @"AmazonCamera.xlsx";

            using (XLUtility xlUtility = new XLUtility(path))
            {
                string sheetName = "Sheet1";
                xlUtility.SetCellData(sheetName, 1, 1, "Camera");
                xlUtility.SetCellData(sheetName, 1, 2, "Camera Prices");

                Console.WriteLine("Writing data to Excel sheet.");

                for (int rowindex = 2; rowindex <= allProducts.Count + 1; rowindex++)
                {
                    xlUtility.SetCellData(sheetName, rowindex, 1, allProducts[rowindex - 2]);
                    xlUtility.SetCellData(sheetName, rowindex, 2, allPrices[rowindex - 2]);
                }

                Console.WriteLine("Data has been written to the Excel sheet.");
            } // The 'xlUtility' object will be automatically disposed here




        }

        [Then(@"Close the opened Browser")]
        public void ThenCloseTheOpenedBrowser()
        {
            //driver.Close();
        }
    }
}
