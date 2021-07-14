using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Module8_TAM.WebDriver;


namespace Module8_TAM
{
    public class LoginPage : AbstractPage
    {
        private IWebElement emailField = Browser.GetDriver().FindElement(By.CssSelector("input[type='email']"));
        private IWebElement passwordField = Browser.GetDriver().FindElement(By.XPath("//input[@type = 'password']"));
        private IWebElement nextButton = Browser.GetDriver().FindElement(By.XPath("//div[@class='FliLIb DL0QTb']//button"));

        public LoginPage() : base(Browser.GetDriver()) { }
        public LoginPage EnterEmail(string email)
        {
            WaitForIsVisible(emailField).SendKeys(email);
            return this;
        }
        public LoginPage ClickNext()
        {
            nextButton.Click();
            return this;
        }
        public LoginPage EnterPassword(string password)
        {
            WaitForIsVisible(passwordField).SendKeys(password);
            return this;
        }
    }
}
