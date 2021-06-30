using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Module7_TAM_V2;
using System.Configuration;

namespace Module7_TAM
{
    [TestFixture]
    public class BaseTest
    {
        private string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");

        [SetUp]
        public void SetUp()
        {
            DriverInstance.OpenStartPage(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            DriverInstance.CloseDriver();
        }
    }
}
