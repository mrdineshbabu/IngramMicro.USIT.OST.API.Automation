//-----------------------------------------------------------------------
// <copyright file="HookInitialize.cs" company="IngramMicro Inc">
//     Copyright (c) IngramMicro Inc. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace IngramMicro.USIT.OST.API.Automation.Hooks
{
    using System;
    using System.Configuration;
    using System.IO;
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Gherkin.Model;
    using AventStack.ExtentReports.Reporter;
    using AventStack.ExtentReports.Reporter.Configuration;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]

    /// <summary>
    /// The Hook Initialize Class
    /// </summary>
    public class HookInitialize
    {
        /// <summary>
        /// The feature name
        /// </summary>
        public static ExtentTest featureName;

        /// <summary>
        /// The Scenario
        /// </summary>
        public static ExtentTest scenario;

        /// <summary>
        /// The Report
        /// </summary>
        public static ExtentReports extent;

        [BeforeTestRun]

        /// <summary>
        /// The Test Initialize Method
        /// </summary>
        public static void TestInitalize()
        {   
           // string resultFolder = Convert.ToString(ConfigurationManager.AppSettings["ResultPath"]);
           // string environment = Convert.ToString(ConfigurationManager.AppSettings["Environment"]);
            
           // if (!Directory.Exists(resultFolder + "\\API Automation Test Results_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")))
           // {
           //     Directory.CreateDirectory(resultFolder + "\\API Automation Test Results_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
           // }

           // ////Initialize Extent report before test starts
           // var htmlReporter = new ExtentHtmlReporter(resultFolder + "\\API Automation Test Results_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + "\\");
           //////Attach report to reporter
           // extent = new ExtentReports();
           // htmlReporter.Config.ReportName = "USIT - OST";
           // extent.AttachReporter(htmlReporter);
           // extent.AddSystemInfo("Environment", environment);            
        }

        [BeforeFeature]

        /// <summary>
        /// The Before Feature Method
        /// </summary>
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Get feature Name

            string resultFolder = Constants.FilePath + "\\OST_API_Result"; //Convert.ToString(ConfigurationManager.AppSettings["ResultPath"]);
            string environment = Convert.ToString(ConfigurationManager.AppSettings["Environment"]);

            if (!Directory.Exists(resultFolder + "\\" + featureContext.FeatureInfo.Title + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")))
            {
                Directory.CreateDirectory(resultFolder + "\\" + featureContext.FeatureInfo.Title + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            }

            ////Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(resultFolder + "\\" + featureContext.FeatureInfo.Title + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + "\\");
            ////Attach report to reporter
            extent = new ExtentReports();
            htmlReporter.Config.ReportName = "Build - " + DateTime.Now.ToString(); ;
            htmlReporter.Config.DocumentTitle = "API Testing Report";
            htmlReporter.Config.Theme = Theme.Standard;
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment", environment);
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterTestRun]

        /// <summary>
        /// The Teardown report Method
        /// </summary>
        public static void TearDownReport()
        {
            ////Flush report once test completes
            extent.Flush();
        }
       
        [BeforeScenario]

        /// <summary>
        /// The Initialize Method
        /// </summary>
        public void Initialize(ScenarioContext _scenarioContext)
        {
            ////Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]

        /// <summary>
        /// The After Each Step Method
        /// </summary>
        public void AfterEachStep(FeatureContext featureContext, ScenarioContext _scenarioContext)
        {
            var featureName = featureContext.FeatureInfo.Title;
            var scenarioName = _scenarioContext.StepContext.StepInfo.Text;
            var stepName = _scenarioContext.StepContext.StepInfo.Text;
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            try
            {
                var exception = _scenarioContext.TestError.ToString();
                if (exception.Contains("NUnit.Framework.SuccessException"))
                {
                    if (stepType == "Given")
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.TestError.Message);
                    }
                    else if (stepType == "When")
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.TestError.Message);
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.TestError.Message);
                    }
                    else if (stepType == "And")
                    {
                        scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass(_scenarioContext.TestError.Message);
                    }
                    Console.WriteLine(exception);
                }
                else
                {
                    if (stepType == "Given")
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    }
                    else if (stepType == "When")
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message); ;
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    }
                }
            }
            catch
            {
                if (_scenarioContext.TestError == null)
                {                    
                    if (stepType == "Given")
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                    else if (stepType == "When")
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                    else if (stepType == "And")
                    {
                        scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                    }
                }
                else if (_scenarioContext.TestError != null)
                {
                    if (stepType == "Given")
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                    }
                    else if (stepType == "When")
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message); ;
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);

                    }
                }
                /*else if (_scenarioContext.TestError.ToString() == "Warn")
                {
                    if (stepType == "Given")
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Warning(_scenarioContext.TestError.Message);
                    }
                    else if (stepType == "When")
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Warning(_scenarioContext.TestError.Message); ;
                    }
                    else if (stepType == "Then")
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Warning(_scenarioContext.TestError.Message);

                    }
                }*/
            }
        }

        [AfterScenario]

        /// <summary>
        /// The After Scenario Method
        /// </summary>
        public void AfterScenario()
        {
            //Flush report once test completes
            extent.Flush();
        }        
    }
}