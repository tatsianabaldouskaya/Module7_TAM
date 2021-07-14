using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using Module8_TAM.WebDriver;

namespace Module8_TAM
{
    [TestFixture]
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
        public IWebElement WaitForIsVisible(IWebElement element)
        {
             return new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
        //public bool isElementDisplayed(IWebElement element, int timeoutSec = 10)
        //{
        //    try
        //    {
        //        _ = Browser.GetDriver().FindElements().Displayed;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
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

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
