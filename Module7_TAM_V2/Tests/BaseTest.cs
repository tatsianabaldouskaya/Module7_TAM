using NUnit.Framework;
using System.Configuration;
using Module7_TAM_V2.WebDriver;
using Module7_TAM_V2.Model;
using Module7_TAM_V2.Utils;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using TestProject.OpenSDK;
using System;


namespace Module7_TAM_V2
{
    [TestFixture]
    public class BaseTest
    {
        private string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");
        protected static Browser Browser = Browser.Instance;
//        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
//(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TestContext TestContext {get; set;}


          [SetUp]
        public void SetUp()
        {
            Logger.InitLogger();
            Logger.Log.Info("Set up");
            Browser Browser = Browser.Instance;
            Browser.OpenStartPage(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Logger.Log.Info("Tear Down");
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Screenshoter.GetScreenshot();
                Logger.Log.Fatal("Test is failed");
                Logger.Log.Error(TestContext.CurrentContext.Result.Message);
            }
            else Logger.Log.Info("Test is passed");
            Browser.CloseDriver();
        }

    }
}
