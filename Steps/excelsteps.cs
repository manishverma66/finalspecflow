using finalspecflow.Hooks;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class excelsteps
    {
        private IWebDriver driver;
        static int rowCount = 3;
        public static string Path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Results");
        public excelsteps(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"Launchh the browser")]
        public void GivenLaunchhTheBrowser()
        {
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population");
            Thread.Sleep(3000);

        }

        [Given(@"Open thee url in chromee")]
        public void GivenOpenTheeUrlInChromee()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("window.scrollBy(0,800)", "");
            Console.WriteLine("sucessfully scrolled to down of web page");

        }

        [When(@"make the entry save in excel sheet")]
        public void WhenMakeTheEntrySaveInExcelSheet()
        {
            IWebElement table = driver.FindElement(By.XPath("//table[@class='wikitable sortable jquery-tablesorter']/tbody"));
            ReadOnlyCollection<IWebElement> rows = table.FindElements(By.XPath("tr"));
            int numberOfRows = rows.Count;
            Console.WriteLine("sucessfully counted");
            //Console.WriteLine("Number of rows in table is"+numberOfRows);
            Console.WriteLine($"Number of rows in the table: {numberOfRows}");
                       
            String path =Path1 + @"records.xlsx";
            using (XLUtility xlUtility = new XLUtility(path))
            {


                Console.WriteLine("Data has been written to the Excel sheet.");
                Console.WriteLine("Excel header will be written");
                xlUtility.SetCellData("Sheet1", 1, 1, "Countryyy");
                xlUtility.SetCellData("Sheet1", 1, 2, "Populations");
                xlUtility.SetCellData("Sheet1", 1, 3, "Percentagee");
                xlUtility.SetCellData("Sheet1", 1, 4, "Datee");
                xlUtility.SetCellData("Sheet1", 1, 5, "Sourcess");
                Console.WriteLine("Excel header defined");
                //xlUtility.Close();

                //writing data in excel
                for (int rowindex = 2; rowindex <= rows.Count; rowindex++)
                {
                    //(//table[@class='two-column td-red'])[1]/tbody/tr/td[2]
                    String Country = table.FindElement(By.XPath("tr[" + rowindex + "]/td[1]")).Text;
                    String Populations = table.FindElement(By.XPath("tr[" + rowindex + "]/td[2]")).Text;
                    String Percentage = table.FindElement(By.XPath("tr[" + rowindex + "]/td[3]")).Text;
                    String Date = table.FindElement(By.XPath("tr[" + rowindex + "]/td[4]")).Text;
                    String Source = table.FindElement(By.XPath("tr[" + rowindex + "]/td[5]")).Text;
                    Console.WriteLine($"Row: {Country} +{Populations} +{Percentage} +{Date} +{Source}");

                    xlUtility.SetCellData("Sheet1", rowindex, 1, Country);
                    xlUtility.SetCellData("Sheet1", rowindex, 2, Populations);
                    xlUtility.SetCellData("Sheet1", rowindex, 3, Percentage);
                    xlUtility.SetCellData("Sheet1", rowindex, 4, Date);
                    xlUtility.SetCellData("Sheet1", rowindex, 5, Source);
                    //xlUtility.Close();

                }

            }
        }


            [Then(@"save the enrtyy")]
            public void ThenSaveTheEnrtyy()
            {
                driver.Close();
            }

        
    }
}







    





