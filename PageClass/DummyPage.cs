using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomationSolutionCSharp.Framework;

namespace TestAutomationSolutionCSharp.PageClass
{
    public class DummyPage : AbstractPage
    {
        private SContext sc;

        By loginButton = By.XPath("//a[text()='Sign in']");
        By userName = By.Id("identifierId");

        public DummyPage(SContext scenarioContext) : base(scenarioContext)
        {
            sc = scenarioContext;
        }

        public Boolean openApp()
        {
            sc.getDriver().Url = "https://www.gmail.com";   
            return true;
        }

        public Boolean loginApp()
        {
            //webClickElement(loginButton);
            webSendKeys(userName, "heyy@gmail.com");
            return true;
        }

        public Boolean closeApp()
        {
            sc.quitDriver();
            return true;
        }
    }
}
