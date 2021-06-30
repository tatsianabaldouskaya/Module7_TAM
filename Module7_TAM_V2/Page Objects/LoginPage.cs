using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using SeleniumExtras.PageObjects;


namespace Module7_TAM
{
    public class LoginPage : AbstractPage
    {
        [FindsBy(How = How.CssSelector, Using = "input[type='email']")]
        private IWebElement emailField;

        [FindsBy(How = How.XPath, Using = "//input[@type = 'password']")]
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//div[@class='FliLIb DL0QTb']//button")]
        private IWebElement nextButton;
        public MailBoxPage LogIn(string email, string password)
        {
            WaitForIsVisible(emailField).SendKeys(email);
            nextButton.Click();
            WaitForIsVisible(passwordField).SendKeys(password);
            nextButton.Click();
            return new MailBoxPage();
        }
    }
}
