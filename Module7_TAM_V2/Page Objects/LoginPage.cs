using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using SeleniumExtras.PageObjects;


namespace Module7_TAM_V2
{
    public class LoginPage : AbstractPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='email']")]
        private IWebElement emailField;

        [FindsBy(How = How.XPath, Using = "//input[@type = 'password']")]
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//div[@class='FliLIb DL0QTb']//button")]
        private IWebElement nextButton;
        public LoginPage EnterEmail(string email)
        {
            WaitForIsVisible(emailField).SendKeys(email);
            return this;
        }
        public LoginPage ClickNext()
        {
            JavaScriptClick(nextButton);
            return this;
        }
        public LoginPage EnterPassword(string password)
        {
            WaitForIsVisible(passwordField).SendKeys(password);
            return this;
        }
    }
}
