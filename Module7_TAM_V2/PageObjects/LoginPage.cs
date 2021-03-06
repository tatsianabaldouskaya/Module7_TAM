using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using SeleniumExtras.PageObjects;
using Module7_TAM_V2.Model;
using Module7_TAM_V2.Elements;
using Module7_TAM_V2.Utils;

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

        public MailBoxPage Login(User user)
        {
            WaitForIsVisible(emailField).SendKeys(user.email);
            JavaScriptClick(nextButton);
            WaitForIsVisible(passwordField).SendKeys(user.password);
            JavaScriptClick(nextButton);           
            return new MailBoxPage();
        }

        public LoginPage EnterEmail(User user)
        {
            WaitForIsVisible(emailField).SendKeys(user.email);
            return this;
        }

        public LoginPage EnterPassword(User user)
        {
            WaitForIsVisible(emailField).SendKeys(user.password);
            return this;
        }
    }
}
