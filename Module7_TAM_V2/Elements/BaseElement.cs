using Module7_TAM_V2.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionHandler = Module7_TAM_V2.Utils.ExceptionHandler;

namespace Module7_TAM_V2.Elements
{
    public class BaseElement
    {
        protected IWebElement element;
        public BaseElement(IWebElement element)
        {
            this.element = element;
        }

        public IWebElement WaitForIsVisible(IWebElement element)
        {
            return new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                Browser.GetDriver().Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(0));
                var isEnabled = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(20)).Until(x => element.Enabled);
                Browser.GetDriver().Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(10));
                return isEnabled;
            }
            catch (NoSuchElementException ex)
            {
                ExceptionHandler.Instance.WriteExceptionLog(ex);
                return false;
            }

            catch (StaleElementReferenceException ex)
            {
                ExceptionHandler.Instance.WriteExceptionLog(ex);
                return false;
            }
        }
    }
}
