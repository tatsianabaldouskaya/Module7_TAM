using Module7_TAM_V2.Model;
using Module7_TAM_V2.PageObjects;
using Module7_TAM_V2.Utils;
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
    public sealed class DeleteByHoverSteps
    {
        private static string baseUrl = ConfigurationManager.AppSettings.Get("baseUrl");
        private readonly ScenarioContext _scenarioContext;
        private string email = UserData.email;
        private string password = UserData.password;
        private string addresseeValue = MessageData.addresseeValue;
        private string subjectValue = MessageData.subjectValue;
        private string bodyValue = MessageData.bodyValue;
        private EntryPage entryPage;
        private LoginPage loginPage;
        private MailBoxPage mailBoxPage;
        private MenuPanel menuPanel;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {        
        Browser Browser = Browser.Instance;
        Browser.OpenStartPage(baseUrl);
        }
       
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public DeleteByHoverSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am logged in my account")]
        public void LogInMyAccount()
        {
            var user = new User(email, password);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            loginPage.Login(user);
        }

        [Given(@"I create new letter")]
        public void CreateNewLetter()
        {
            var bodyValue = Randomizer.RandomString(10, true);
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            menuPanel.OpenNewMessageForm()
               .FillNewMessageFields(message)
               .SaveDraft();
        }

        [Given(@"I open drafts folder")]
        public void OpenDraftsFolder()
        {
            menuPanel.OpenDraftsFolder();
        }

        [When(@"I hover the letter")]
        public void HoverTheLetter()
        {
            var letter = mailBoxPage.HoverLetter();
        }

        [When(@"I click basket icon")]
        public void ClickBasketIcon()
        {
            mailBoxPage.JsClickDeleteLetter();
        }

        [Then(@"letter is deleted from the folder")]
        public void LetterIsDeletedFromTheFolder()
        {
            Assert.IsFalse(mailBoxPage.IsLetterDisplayed()
             , "Letter is not removed from draft folder");
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Browser.CloseDriver();
        }

    }
}
