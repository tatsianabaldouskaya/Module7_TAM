using Module7_TAM_V2.Model;
using NUnit.Framework;
using System.Configuration;
using Module7_TAM_V2.Utils;
using System;
using System.Threading;
using Module7_TAM_V2.States;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Module7_TAM_V2.PageObjects;

namespace Module7_TAM_V2
{
    [TestFixture]
    [Parallelizable]
    class MailBoxTests : BaseTest
    {
        private string email = UserData.email;
        private string password = UserData.password;
        private string addresseeValue = MessageData.addresseeValue;
        private string subjectValue = MessageData.subjectValue;
        private string bodyValue = MessageData.bodyValue;
        private EntryPage entryPage;
        private LoginPage loginPage;
        private MailBoxPage mailBoxPage;
        private MenuPanel menuPanel;
        [Test]
        public void LoginTest()
        {
            var user = new User(email, password);
            entryPage = new EntryPage();
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            entryPage.OpenLoginForm();
            loginPage.Login(user);
            var userIcon = mailBoxPage.ClickUserIcon();           
            Assert.AreEqual(email, userIcon.GetActualEmail(),
                "Login is unsuccessful");
        }

        [Test]
        public void CreateDraftEmailAndSendTest()
        {
            var bodyValue = Randomizer.RandomString(10, true);
            var user = new User(email, password);
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            mailBoxPage = menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(message)
                .SaveDraft()
                .OpenDraftsFolder();
            Assert.IsTrue(mailBoxPage.IsLetterDisplayed(), "Draft is not saved");
            var savedMessage = mailBoxPage.OpenMessage();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(message.addresseeValue, savedMessage.GetSavedMessageAddressee(),
                    "Addressee doesn't correspond to expected");
                Assert.AreEqual(message.subjectValue, savedMessage.GetActualSubject(),
                    "Subject doesn't correspond to expected");
                Assert.AreEqual(message.bodyValue, savedMessage.GetSavedMessageBody(),
                    "Body doesn't correspond to expected");
            });
            Screenshoter.GetScreenshot();
            var sentMessage = savedMessage.SendMessage();
            sentMessage = menuPanel.OpenSentFolder();
            Assert.IsTrue(sentMessage.IsLetterDisplayed(),
                "Letter is absent in send folder");
        }

        [Test]
        public void LogoutTest()
        {
            var user = new User(email, password);
            entryPage = new EntryPage();
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            entryPage.OpenLoginForm()
                .Login(user);
            var signedOutText = mailBoxPage.ClickUserIcon()
                 .ClickSignOut();
            Assert.IsTrue(signedOutText.IsSignedOutTextDisplayed(), "You are not logged off");
        }      

        [Test]
        public void HighlightTestD()
        {
            var user = new User(email, password);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            var folder = new FolderD();
            folder.HighLight(menuPanel.GetDraftsFolder());
            Assert.IsTrue(folder.CheckCurrentState(menuPanel.GetDraftsFolder()), "Draft folder is not highlighted");
            folder.UnHighlight(menuPanel.GetDraftsFolder());
            folder.HighLight(menuPanel.GetSentFolder());
            Assert.Multiple(() =>
            {
                Assert.IsFalse(folder.CheckCurrentState(menuPanel.GetDraftsFolder()), "Draft folder is highlighted");
                Assert.IsTrue(folder.CheckCurrentState(menuPanel.GetSentFolder()), "Sent folder is not highlighted");
            });
        }

        [Test]
        public void DeleteLetterByHoverTest()
        {
            var user = new User(email, password);
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(message)
                .SaveDraft();
            var letter = menuPanel.OpenDraftsFolder()
                .HoverLetter()
                .JsClickDeleteLetter();
            Assert.IsFalse(letter.IsLetterDisplayed()
             , "Letter is not removed from draft folder");
        }

        [Test]
        public void DragAndDropToStarredTest()
        {
            var user = new User(email, password);
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            var starIcon = menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(message)
                .SaveDraft()
                .OpenDraftsFolder()
                .DragAndDropToStarred();
            Assert.IsTrue(starIcon.IsStarIconActive(), "Draft is not saved");
        }

        [Test]
        public void DeleteLetterByRightMouseClickTest()
        {
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            var user = new User(email, password);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            var draftEmail = menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(message)
                .SaveDraft(); ;
            var letter = draftEmail.OpenDraftsFolder()
                .RightClickLetterAndDelete();
            Assert.IsFalse(letter.IsLetterDisplayed(), "Draft is not deleted");
        }
    }
}