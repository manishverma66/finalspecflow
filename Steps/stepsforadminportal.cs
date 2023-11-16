using finalspecflow.POM;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;

namespace finalspecflow.Steps
{
    [Binding]
    public class stepsforadminportal
    {
        private IWebDriver driver;
        static int rowCount = 3;
        public static string Path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "\\Results");
        String Baseurl = "http://live.techpanda.org/index.php/backendlogin/index/index/key/b61d75d1e41a375be14cc08718f3bf65/";
        pom Call = new pom();
        public stepsforadminportal(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"Launch the chrome browser and open the url for admin portal")]
        public void GivenLaunchTheChromeBrowserAndOpenTheUrlForAdminPortal()
        {
            driver.Navigate().GoToUrl(Baseurl);
            Thread.Sleep(3000);
        }
        
        [Given(@"Eneter a valid userid (.*) and password (.*) to make loginb")]
        public void GivenEneterAValidUseridAndPasswordToMakeLoginb(string emailid, string password)
        {
            Call.enterEmailforadminportal(emailid, password); 
            Thread.Sleep(1000);
        }
        
        [When(@"Click on the login button to login")]
        public void WhenClickOnTheLoginButtonToLogin()
        {
            driver.FindElement(By.XPath("//input[@title='Login']")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//span[normalize-space()='close']")).Click();
            Console.WriteLine($"Home page has been sucessfully launched now doing web scrapping");

        }

        [Then(@"Save the data in exel sheet")]
        public void ThenSaveTheDataInExelSheet()
        {
            IWebElement table = driver.FindElement(By.XPath("//table[@id='customerGrid_table']/tbody"));
            ReadOnlyCollection<IWebElement> rows = table.FindElements(By.XPath("tr"));
            int numberOfRows = rows.Count;
            Console.WriteLine("sucessfully counted rows for table");

            Console.WriteLine($"Number of rows in the table: {numberOfRows}");



            //writing data in excel
            for (int rowindex = 1; rowindex <= rows.Count; rowindex++)
            {
                //(//table[@class='two-column td-red'])[1]/tbody/tr/td[2]
                String ID = table.FindElement(By.XPath("tr[" + rowindex + "]/td[2]")).Text;
                String Name = table.FindElement(By.XPath("tr[" + rowindex + "]/td[3]")).Text;
                String Email = table.FindElement(By.XPath("tr[" + rowindex + "]/td[4]")).Text;
                String Group = table.FindElement(By.XPath("tr[" + rowindex + "]/td[5]")).Text;
                String Telephone = table.FindElement(By.XPath("tr[" + rowindex + "]/td[6]")).Text;
                String ZIP = table.FindElement(By.XPath("tr[" + rowindex + "]/td[7]")).Text;
                String Country = table.FindElement(By.XPath("tr[" + rowindex + "]/td[8]")).Text;
                String State = table.FindElement(By.XPath("tr[" + rowindex + "]/td[9]")).Text;
                String Custumer = table.FindElement(By.XPath("tr[" + rowindex + "]/td[10]")).Text;
                String Action = table.FindElement(By.XPath("tr[" + rowindex + "]/td[11]")).Text;

                Console.WriteLine($"Row: {ID} +{Name} +{Email} +{Group} +{Telephone} +{ZIP} +{Country} +{State} +{Custumer} +{Action}");


                String path = Path1 + @"Adminportal.xlsx";
                using (XLUtility xlUtility = new XLUtility(path))
                {


                    Console.WriteLine("Data has been written to the Excel sheet.");
                    Console.WriteLine("Excel header will be written");
                    xlUtility.SetCellData("Sheet1", 1, 1, "ID");
                    xlUtility.SetCellData("Sheet1", 1, 2, "Name");
                    xlUtility.SetCellData("Sheet1", 1, 3, "Email");
                    xlUtility.SetCellData("Sheet1", 1, 4, "Group");
                    xlUtility.SetCellData("Sheet1", 1, 5, "Telephone");
                    xlUtility.SetCellData("Sheet1", 1, 6, "ZIP");
                    xlUtility.SetCellData("Sheet1", 1, 7, "Country");
                    xlUtility.SetCellData("Sheet1", 1, 8, "State");
                    xlUtility.SetCellData("Sheet1", 1, 9, "Custumer");
                    xlUtility.SetCellData("Sheet1", 1, 10, "Action");


                    Console.WriteLine("Excel header defined");
                    //xlUtility.Close();

                    xlUtility.SetCellData("Sheet1", rowindex, 1, ID);
                    xlUtility.SetCellData("Sheet1", rowindex, 2, Name);
                    xlUtility.SetCellData("Sheet1", rowindex, 3, Email);
                    xlUtility.SetCellData("Sheet1", rowindex, 4, Group);
                    xlUtility.SetCellData("Sheet1", rowindex, 5, Telephone);
                    xlUtility.SetCellData("Sheet1", rowindex, 6, ZIP);
                    xlUtility.SetCellData("Sheet1", rowindex, 7, Country);
                    xlUtility.SetCellData("Sheet1", rowindex, 8, State);
                    xlUtility.SetCellData("Sheet1", rowindex, 9, Custumer);
                    xlUtility.SetCellData("Sheet1", rowindex, 10, Action);


                    //driver.Close();
                    Console.WriteLine("Data has been written to the Excel sheet and web scrapping done sucessfullys.");


                }


            }
        }

        [Then(@"close tge opened bwowser")]
        public void ThenCloseTgeOpenedBwowser()
        {
            driver.Close();
        }

    }
}
