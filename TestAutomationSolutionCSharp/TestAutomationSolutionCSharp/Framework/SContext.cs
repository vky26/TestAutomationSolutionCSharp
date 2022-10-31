using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Globalization;
using System.IO;

namespace TestAutomationSolutionCSharp.Framework
{
    public class SContext
    {
        private IWebDriver driver;
        private InitDriver initDriver = new InitDriver();

        public IWebDriver getDriver()
        {
            if (null == driver)
            {
                driver = initDriver.makeDriver();
                // Maximize current window
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public void quitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        public string screenshotAsBase64String()
        {
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            return Convert.ToBase64String(screenshot.AsByteArray);
        }

        public String getRandomDateString()
        {
            Random r = new Random();
            int low = 150;
            int high = 400;
            int result = r.Next(high - low) + low;

            return DateTime.Now.AddDays(result).ToString("dd-MM-yyyy");
           
        }

        public String readJSONData(String obj, String node) 
        {
            JObject data = JObject.Parse(File.ReadAllText(@"..\..\\..\\resources\\data\\prodconfig.json"));
            var myJsonString = JObject.Parse(data.ToString());
            var jo = JObject.Parse(myJsonString.ToString());
            var val = jo[obj][node].ToString();
            return val;
        }

    }
}
