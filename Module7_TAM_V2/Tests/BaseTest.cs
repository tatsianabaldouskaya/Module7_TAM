using NUnit.Framework;
using System.Configuration;
using Module7_TAM_V2.WebDriver;
using Module7_TAM_V2.Model;

namespace Module7_TAM_V2
{
    [TestFixture]
    public class BaseTest
    {
        private string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");

        public TestContext TestContext {get; set;}

        [SetUp]
        public void SetUp()
        {
            Browser Browser = Browser.Instance;
            Browser.OpenStartPage(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.CloseDriver();
        }
    }
}
