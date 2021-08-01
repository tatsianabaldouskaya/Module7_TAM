﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Module7_TAM_V2.WebDriver;
using ExceptionHandler = Module7_TAM_V2.Utils.ExceptionHandler;

namespace Module7_TAM_V2
{
    [TestFixture]
    public abstract class AbstractPage
    {   
        public AbstractPage()
        {
            PageFactory.InitElements(Browser.GetDriver(), this);
        }
        public static IWebElement WaitForIsVisible(IWebElement element)
        {
            return new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(20)).Until(x => element.Displayed);
                return true;
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

        //public IWebElement JavaScriptHighlight(IWebElement element)
        //{
        //    IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
        //    js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
        //    return element;
        //}

        //public void JavaScriptUnhighlight(IWebElement element)
        //{
        //    IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
        //    js.ExecuteScript("arguments[0].style.backgroundColor = '" + "white" + "'", element);
        //}

        //public bool IsElementHighlighted(IWebElement element)
        //{
        //    string color = "rgba(255, 255, 0, 1)";
        //    string actColor = element.GetCssValue("background-color");
        //    if (color == actColor)
        //    {
        //        return true;
        //    }
        //    else return false;
        //}
    }
}