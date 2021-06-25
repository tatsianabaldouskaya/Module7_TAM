using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Module7_TAM
{
    public class LogOutPage:AbstractPage
    {
        private By signedOutText = By.XPath("//div[text()= 'Вы не вошли в аккаунт']");
        public LogOutPage(IWebDriver driver) : base(driver) { }    
        public By GetSignedOutText()
        {
            return signedOutText;
        }
    }
}
