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
    public class LogOutPage : AbstractPage
    {
        private IWebElement signedOutText = Browser.GetDriver().FindElement(By.XPath("//div[text()= 'Вы не вошли в аккаунт']"));
        public LogOutPage() : base(Browser.GetDriver()) { }
        public IWebElement GetSignedOutText()
        {
            return signedOutText;
        }
    }
}
