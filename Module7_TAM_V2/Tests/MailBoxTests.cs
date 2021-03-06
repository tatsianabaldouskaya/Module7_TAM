using Module7_TAM_V2.Model;
using NUnit.Framework;
using System.Configuration;
using Module7_TAM_V2.Utils;
using System;
using System.Threading;
using Module7_TAM_V2.States;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Drawing.Imaging;
using NUnit.Framework.Interfaces;
using TestProject.OpenSDK;

namespace Module7_TAM_V2
{
    [TestFixture]
    [Parallelizable]
    class MailBoxTests : BaseTest
    {
       // private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string email = UserData.email;
        private string password = UserData.password;
        private string addresseeValue = MessageData.addresseeValue;
        private string subjectValue = MessageData.subjectValue;
        private string bodyValue = MessageData.bodyValue;
        private LoginPage loginPage;
        private MailBoxPage mailBoxPage;
        private MenuPanel menuPanel;
        [Test]
        public void LoginTest()
        {
            Logger.Log.Info("Login test is launched");
            var user = new User(email, password);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            Logger.Log.Debug("User is logged in with email " + user.email);
            var userIcon = mailBoxPage.ClickUserIcon();
            Assert.AreEqual(email, userIcon.GetActualEmail(), "Login is unsuccessful");
        }

        [Test]
        public void CreateDraftEmailAndSendTest()
        {
            Logger.Log.Info("CreateDraftEmailAndSendTest is launched");
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
            var sentMessage = savedMessage.SendMessage();
            sentMessage = menuPanel.OpenSentFolder();
            Assert.IsTrue(sentMessage.IsLetterDisplayed(),
                "Letter is absent in send folder");
        }

        [Test]
        public void LogoutTest()
        {
            Logger.Log.Info("LogoutTest is launched");
            var user = new User(email, password);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            loginPage.Login(user);
            var signedOutText = mailBoxPage.ClickUserIcon()
                 .ClickSignOut();
            Assert.IsTrue(signedOutText.IsSignedOutTextDisplayed(), "You are not logged off");
        }      

        [Test]
        public void HighlightTestD()
        {
            Logger.Log.Info("HighlightTestD is launched");
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
            Logger.Log.Info("DeleteLetterByHoverTest is launched");
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
            Logger.Log.Info("DragAndDropToStarredTest is launched");
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
            Logger.Log.Info("DeleteLetterByRightMouseClickTest is launched");
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