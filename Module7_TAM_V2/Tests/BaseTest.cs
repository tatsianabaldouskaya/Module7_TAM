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
        protected static Browser Browser = Browser.Instance;
        protected LoginPage loginPage;
        protected MailBoxPage mailBoxPage;
        protected MenuPanel menuPanel;

        public TestContext TestContext {get; set;}

        [SetUp]
        public void SetUp()
        {
            Browser = Browser.Instance;
            Browser.OpenStartPage(baseUrl);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
        }

        [TearDown]
        public void TearDown()
        {
            Browser.CloseDriver();
        }
    }
}
