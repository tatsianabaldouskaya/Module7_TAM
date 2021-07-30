using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.PageObjects
{
    public class EntryPage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//ul[@class = 'h-c-header__cta-list header__nav--ltr']//a[@data-action = 'sign in']")]
        private IWebElement logInButton;

        public LoginPage OpenLoginForm()
        {
            WaitForIsVisible(logInButton).Click();
            return new LoginPage();
        }
    }
}
