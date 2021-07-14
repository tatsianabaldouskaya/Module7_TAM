using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using Module8_TAM.WebDriver;

namespace Module8_TAM
{
    [TestFixture]
    public class BaseTest
    {
        //статический браузер, чтобы был только 1 инстанс в каждом тесте
        protected static Browser browser = Browser.Instance;
        private string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");

        [SetUp]
        public void SetUp()
        {
            Browser.OpenStartPage(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.CloseDriver();
        }
    }
}
