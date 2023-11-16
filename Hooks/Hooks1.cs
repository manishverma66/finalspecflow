using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using finalspecflow.utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace finalspecflow.Hooks
{
    [Binding]
    public class Hooks1 : ExtentReport
    {
        private readonly IObjectContainer iob;
        public static IWebDriver driver;

        public Hooks1(IObjectContainer iob)
        {
            this.iob = iob;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario("@Launch MHC website and make login into application with users account")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            //scenario = feature.CreateNode(context.ScenarioInfo.Title);


            Console.WriteLine("Running before scenario...");
            driver= new ChromeDriver();
            driver.Manage().Window.Maximize();
            iob.RegisterInstanceAs<IWebDriver>(driver);
            //driver.Url = "https://melanatedhealthqa.web.app/";
            //driver.Url = "https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population";
            //driver.Url = "https://www.amazon.in/";
            driver.Url = "https://unstop.com/auth/login";
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
           

        }
        

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = iob.Resolve<IWebDriver>();
            Console.WriteLine("Running after scenario...");
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            //var driver = _container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }

    }
}
