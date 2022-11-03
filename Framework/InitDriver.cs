using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium;

namespace TestAutomationSolutionCSharp.Framework
{
    public class InitDriver
    {
        public IWebDriver makeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver(options);
        }
        
    }
}
