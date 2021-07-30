using Module7_TAM_V2.Model;
using Module7_TAM_V2.WebDriver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Module7_TAM_V2.Steps
{
    [Binding]
    public sealed class LogOutSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private static string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");
        private readonly ScenarioContext _scenarioContext;
        private LoginPage loginPage;
        private MailBoxPage mailBoxPage;
        private LogOutPage logOutPage;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Browser Browser = Browser.Instance;
            Browser.OpenStartPage(baseUrl);
        }

        public LogOutSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        //[Given(@"I am logged in my account")]
        //public void LogInMyAccount()
        //{
        //    var user = new User(email, password);
        //    loginPage = new LoginPage();
        //    mailBoxPage = new MailBoxPage();
        //    loginPage.Login(user);
        //}

        [When(@"I click user icon")]
        public void ClickUserIcon()
        {
            mailBoxPage.ClickUserIcon();
        }

        [When(@"I click Sign out button")]
        public void ClickSignOut()
        {
            mailBoxPage.ClickSignOut();
        }

        [Then(@"Signed out text is displayed")]
        public void SignedOutTextIsDisplayed()
        {
            Assert.IsTrue(logOutPage.IsSignedOutTextDisplayed(), "You are not logged off");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Browser.CloseDriver();
        }
    }
}
