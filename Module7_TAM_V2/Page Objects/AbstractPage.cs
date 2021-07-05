using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using SeleniumExtras;
using SeleniumExtras.PageObjects;
using Module7_TAM_V2;

namespace Module7_TAM
{
    [TestFixture]
    public abstract class AbstractPage
    {   
        public AbstractPage()
        {
            PageFactory.InitElements(DriverInstance.GetDriver(), this);
        }
        public IWebElement WaitForIsVisible(IWebElement element)
        {
            return new WebDriverWait(DriverInstance.GetDriver(), TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        protected bool isElementDisplayed(IWebElement element)
        {
            try
            {
                var elementToBeDisplayed = element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }           
    }
}