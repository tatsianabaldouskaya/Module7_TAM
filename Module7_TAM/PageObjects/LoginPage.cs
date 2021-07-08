using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace Module7_TAM
{
    public class LoginPage: AbstractPage
    {
        private By emailField = By.CssSelector("input[type='email']");
        private By passwordField = By.XPath("//input[@type = 'password']");
        private By nextButton = By.XPath("//div[@class='FliLIb DL0QTb']//button");       

        public LoginPage(IWebDriver driver) : base(driver) { }
        public MailBoxPage LogIn(string email, string password)
        {
            WaitForIsVisible(emailField);
            SendKeys(emailField, email);
            JavaScriptClick(nextButton);
            WaitForIsVisible(passwordField);
            SendKeys(passwordField, password);
            JavaScriptClick(nextButton);
            return new MailBoxPage(driver);
        }
    }
}
