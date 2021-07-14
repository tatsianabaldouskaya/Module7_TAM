using Module7_TAM_V2.Model;
using NUnit.Framework;
using System.Configuration;

namespace Module7_TAM_V2
{
    [TestFixture]
    [Parallelizable]
    class MailBoxTests : BaseTest
    {
        private string email = ConfigurationManager.AppSettings["email"];
        private string password = ConfigurationManager.AppSettings["password"];
        private string addresseeValue = ConfigurationManager.AppSettings["addresseeValue"];
        private string subjectValue = ConfigurationManager.AppSettings["subjectValue"];
        private string bodyValue = ConfigurationManager.AppSettings["bodyValue"];

        private LoginPage loginPage;
        private MailBoxPage mailBoxPage;
        private MenuPanel menuPanel;

        [Test]
        public void LoginTest()
        {
            var user = new User(email, password);
            loginPage = new LoginPage();
            loginPage.Login(user)
            .ClickUserIcon();
            Assert.AreEqual(email, mailBoxPage.GetActualEmail()
              , "Login is unsuccessful");
        }

        [Test]
        public void CreateDraftEmailAndSendTest()
        {
            var user = new User(email, password);
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            loginPage = new LoginPage();
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
                Assert.AreEqual(addresseeValue, savedMessage.GetSavedMessageAddressee(),
                    "Addressee doesn't correspond to expected");
                Assert.AreEqual(subjectValue, savedMessage.GetActualSubject(),
                    "Subject doesn't correspond to expected");
                Assert.AreEqual(bodyValue, savedMessage.GetSavedMessageBody(),
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
            var user = new User(email, password);
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            loginPage.Login(user);
            var signedOutText = mailBoxPage.ClickUserIcon()
                 .ClickSignOut(); 
            Assert.IsTrue(signedOutText.IsSignedOutTextDisplayed(), "You are not logged off");
        }

        [Test]
        public void HighlightTest()
        {
            var user = new User(email, password);
            loginPage = new LoginPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            menuPanel.HighlightDraftsFolder();
            Assert.IsTrue(menuPanel.IsDraftFolderHighlighted(), "Draft folder is not highlighted");
            menuPanel.HighlightSentFolder();
            Assert.Multiple(() =>
            {
                Assert.IsFalse(menuPanel.IsDraftFolderHighlighted(), "Draft folder is highlighted");
                Assert.IsTrue(menuPanel.IsSentFolderHighlighted(), "Sent folder is not highlighted");
            });               
        }

        [Test]
        public void DeleteLetterByHoverTest()
        {
            var user = new User(email, password);
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            loginPage = new LoginPage();
            menuPanel = new MenuPanel();
            loginPage.Login(user);
            menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(message)
                .SaveDraft()
                .OpenDraftsFolder()
                .HoverLetter()
                .JsClickDeleteLetter();
            Assert.IsFalse(mailBoxPage.IsLetterDisplayed()
             , "Letter is not removed from draft folder");
        }

        [Test]
        public void DragAndDropToStarredTest()
        {
            var user = new User(email, password);
            var message = new Message(addresseeValue, subjectValue, bodyValue);
            loginPage = new LoginPage();
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
            var letter = menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(message)
                .SaveDraft()
                .OpenDraftsFolder()
                .RightClickLetterAndDelete();
            Assert.IsFalse(letter.IsLetterDisplayed(), "Draft is not saved");
        }
    }
}