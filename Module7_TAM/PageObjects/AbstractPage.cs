using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Module7_TAM
{
    [TestFixture]
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void WaitForIsVisible(By locator)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(locator);
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });               
        }
        public bool isElementDisplayed(By locator)
        {
            try
            {
                _ = driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }           
        //public string GetElementText(By locator)
        //{
        //    return driver.FindElement(locator).Text;
        //}
        public void SendKeys(By locator, string text)
        {
           // WaitForElementVisible(driver, locator);
            driver.FindElement(locator).SendKeys(text);
        }
        public void Click(By locator)
        {
           // WaitForElementClickable(driver, locator);
            driver.FindElement(locator).Click();
        }

        public void JavaScriptClick(By locator)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", locator);
        }
    }
}
