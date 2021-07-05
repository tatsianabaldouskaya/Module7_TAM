using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Module7_TAM
{
    public class LogOutPage:AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//div[text()= 'Вы не вошли в аккаунт']")]
        private IWebElement signedOutText;
        private IWebElement GetSignedOutText()
        {
            WaitForIsVisible(signedOutText);
            return signedOutText;
        }

        public bool IsSignedOutTextDisplayed() 
        {
            return isElementDisplayed(GetSignedOutText());
        }
    }
}
