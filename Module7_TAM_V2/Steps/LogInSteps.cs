using Module7_TAM_V2.Model;
using Module7_TAM_V2.WebDriver;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Module7_TAM_V2.Steps
{
    [Binding]
    public sealed class LogInSteps
    {
        private static string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");
        private string email = UserData.email;
        private string password = UserData.password;
        private LoginPage loginPage = new LoginPage();

        [BeforeScenario]
        public static void BeforeScenario()
        {
            Browser Browser = Browser.Instance;
            Browser.OpenStartPage(baseUrl);
        }

        [Given(@"I am logged in my account")]
        public void LogInMyAccount()
        {
            var user = new User(email, password);
            loginPage.Login(user);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Browser.CloseDriver();
        }
    }
}
