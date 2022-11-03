using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework.Internal;

namespace TestAutomationSolutionCSharp.Framework
{
    public class AbstractPage
    {
        private int driverWaitTime = 30;
        protected IWebDriver driver;

        public AbstractPage(SContext scenarioContext)
        {
            driver = scenarioContext.getDriver();
        }
        public Boolean webClickElement(By ele)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(driverWaitTime));
            wait.Until(ExpectedConditions.ElementIsVisible(ele));

            driver.FindElement(ele).Click();
            return true;
        }

        public Boolean webClickElement(IWebElement ele)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(driverWaitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(ele));
            ele.Click();
            return true;
        }


        public Boolean getWebElementVisible(By ele)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(driverWaitTime));
            wait.Until(ExpectedConditions.ElementExists(ele));
            return true;
        }

        public Boolean webSendKeys(By ele, String input)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(driverWaitTime));
            wait.Until(ExpectedConditions.ElementExists(ele));
            driver.FindElement(ele).SendKeys(input);
            return true;
        }

        public Boolean webSendKeys(IWebElement ele, String input)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(driverWaitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(ele));
            ele.SendKeys(input);
            return true;
        }

        public Boolean switchToIFrame(String frameId)
        {
            driver.SwitchTo().Frame(frameId); //switch to frame
            return true;
        }

        public Boolean selectDropDownByName(String dropDownName, String dropDownValue)
        {
            SelectElement drpCountry = new SelectElement(driver.FindElement(By.Name(dropDownName)));
            drpCountry.SelectByText(dropDownValue);
            return true;
        }

        public void jsClickWithoutWait(IWebElement ele)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", ele);
        }

        public void webClearField(IWebElement ele)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(driverWaitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(ele));
            ele.Clear();

        }

        public Boolean webIsElementDisplayed(IWebElement ele)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(driverWaitTime));
                wait.Until(ExpectedConditions.ElementToBeClickable(ele));
                return true;
            }catch(Exception e)
            {
                return false;
            }
           

        }

        public string screenshotAsBase64String()
        {
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            return Convert.ToBase64String(screenshot.AsByteArray);
        }

    }
}
