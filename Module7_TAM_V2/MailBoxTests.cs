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
        private string addresseeValue = "tatiana95.77@gmail.com";
        private string subjectValue = "For test";
        private string bodyValue = "This is test email";

        private LoginPage loginPage;
        private MailBoxPage mailBoxPage;
        private MenuPanel menuPanel;
        private LogOutPage logOutPage;

        [Test]
        public void CreateDraftEmailAndSendTest()
        {
            loginPage = new LoginPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            mailBoxPage = menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft()
                .OpenDraftsFolder();
            Assert.IsTrue(mailBoxPage.IsLetterDisplayed(), "Draft is not saved");
            var message = mailBoxPage.OpenMessage();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(addresseeValue, message.GetSavedMessageAddressee(),
                    "Addressee doesn't correspond to expected");
                Assert.AreEqual(subjectValue, message.GetActualSubject(),
                    "Subject doesn't correspond to expected");
                Assert.AreEqual(bodyValue, message.GetSavedMessageBody(),
                    "Body doesn't correspond to expected");
            });
            var sentMessage = message.SendMessage();
            sentMessage = menuPanel.OpenSentFolder();
            Assert.IsTrue(sentMessage.IsLetterDisplayed(),
                "Letter is absent in send folder");
        }

        [Test]
        public void LogoutTest()
        {
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage(); 
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            logOutPage = mailBoxPage.ClickUserIcon()
                 .ClickSignOut();
            Assert.IsTrue(logOutPage.IsSignedOutTextDisplayed(), "You are not logged off");           
        }

        [Test]
        public void HighlightTest()
        {
            loginPage = new LoginPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenDraftsFolder();
            menuPanel.HighlightDraftsFolder();
            Assert.IsTrue(menuPanel.IsDraftFolderHighlighted(), "Draft folder is not highlighted");
            menuPanel.OpenSentFolder();
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
            loginPage = new LoginPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft()
                .OpenDraftsFolder()
                .HoverLetter()
                .JsClickDeleteLetter();
            Assert.IsFalse(mailBoxPage.IsLetterDisplayed()
             ,"Letter is not removed from draft folder");
        }

        [Test]
        public void DragAndDropToStarredTest()
        {
            loginPage = new LoginPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft()
                .OpenDraftsFolder()
                .DragAndDropToStarred();
            Assert.IsTrue(mailBoxPage.IsStarIconActive(), "Draft is not saved");
        }
       
        [Test]
        public void DeleteLetterByRightMouseClickTest()
        {
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenNewMessageForm()
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft()
                .OpenDraftsFolder()
                .RightClickLetterAndDelete();
            Assert.IsFalse(mailBoxPage.IsLetterDisplayed(), "Draft is not saved");
        }
    }
}