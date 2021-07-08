﻿using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using SeleniumExtras;
using SeleniumExtras.PageObjects;
using Module7_TAM_V2.WebDriver;

namespace Module7_TAM_V2
{
    [TestFixture]
    public abstract class AbstractPage
    {   
        public AbstractPage()
        {
            PageFactory.InitElements(Browser.GetDriver(), this);
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
                var isEnabled =  new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(20)).Until(x => element.Enabled);
                Browser.GetDriver().Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(10));
                return isEnabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            catch (StaleElementReferenceException)
            {
                return false;
            }
        }
        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Browser.GetDriver();
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public IWebElement JavaScriptHighlight(IWebElement element)
        {
            IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
            return element;
        }

        public void JavaScriptUnhighlight(IWebElement element)
        {
            IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "white" + "'", element);
        }
    }
}