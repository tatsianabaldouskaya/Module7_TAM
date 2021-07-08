using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using Module7_TAM_V2.WebDriver;

namespace Module7_TAM_V2
{
    [TestFixture]
    public class BaseTest
    {
        private string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");
        protected static Browser Browser = Browser.Instance;

        [SetUp]
        public void SetUp()
        {
            Browser = Browser.Instance;
            Browser.OpenStartPage(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.CloseDriver();
        }
    }
}
