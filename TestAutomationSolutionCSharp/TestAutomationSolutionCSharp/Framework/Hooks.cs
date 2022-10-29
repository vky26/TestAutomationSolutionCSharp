using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace TestAutomationSolutionCSharp.Framework
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SContext sc=null;

        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, step;
        static string reportPath = Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Reports"
            + Path.DirectorySeparatorChar + "Html_Report_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "\\";

        public Hooks(SContext scenarioContext)
        {
            sc = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            AbstractPage page = new AbstractPage(sc);
            if (null == context.TestError)
            {
                step.Log(Status.Pass, context.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(sc.screenshotAsBase64String()).Build());
            }
            else 
            {
                step.Log(Status.Fail, context.StepContext.StepInfo.Text, MediaEntityBuilder.CreateScreenCaptureFromBase64String(sc.screenshotAsBase64String()).Build());
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            sc.quitDriver();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }
    }
}
