using Module7_TAM_V2.Model;
using Module7_TAM_V2.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Module7_TAM_V2.Steps
{
    [Binding]
    public sealed class DeleteByHoverSteps
    {
        private string addresseeValue = MessageData.addresseeValue;
        private string subjectValue = MessageData.subjectValue;
        private MailBoxPage mailBoxPage = new MailBoxPage();
        private MenuPanel menuPanel = new MenuPanel();

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
            mailBoxPage.HoverLetter();
        }

        [When(@"I click basket icon")]
        public void ClickBasketIcon()
        {
            var letter = mailBoxPage.JsClickDeleteLetter();
        }

        [Then(@"letter is deleted from the folder")]
        public void LetterIsDeletedFromTheFolder()
        {
            Assert.IsFalse(mailBoxPage.IsLetterDisplayed()
             , "Letter is not removed from draft folder");
        }
    }
}
