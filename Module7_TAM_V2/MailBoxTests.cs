using NUnit.Framework;
using System.Threading;
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
        private string urlSent = "https://mail.google.com/mail/u/0/#sent";

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
            // check here that "Message set is shown" on the page
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
            //refactor the assert
            //Assert.IsTrue(logOutPage.IsElementDisplayed(logOutPage.GetSignedOutText()), "You are not logged off");           
        }

        //Javascript executor
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
            //invoke highlight method
            //add assert
            menuPanel.OpenSentFolder();
            //Assert.AreEqual(urlSent, );
        }

        //Actions with mouse
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
            //refactor the assert
            //Assert.IsFalse(mailBoxPage.IsElementDisplayed(mailBoxPage.GetLetter())
            // ,"Letter is not removed from draft folder");
        }

        //Test with Driver actions class Mouse
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
            //refactor the assert
            //Assert.IsTrue(mailBoxPage.IsElementDisplayed(starIconActive), "Draft is not saved");
        }
       
        //Test with driver actions Class Keyboard
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
            //refactor the assert
            //Assert.IsFalse(mailBoxPage.IsElementDisplayed(mailBoxPage.GetLetter()), "Draft is not saved");
        }
    }
}