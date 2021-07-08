using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Collections.Specialized;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

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

        [FindsBy(How = How.XPath, Using = "//span[@aria-label = 'Starred']")]
        public IWebElement starIconActive;

        LoginPage loginPage;
        MailBoxPage mailBoxPage;
        MenuPanel menuPanel;
        LogOutPage logOutPage;

        [Test]
        public void CreateDraftEmailAndSendTest()
        {
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenNewMessageForm();
            mailBoxPage
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft();
            menuPanel.OpenDraftsFolder();
            Assert.IsTrue(mailBoxPage.IsElementDisplayed(mailBoxPage.GetLetter()), "Draft is not saved");
            mailBoxPage.OpenMessage();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(addresseeValue, mailBoxPage.GetSavedMessageAddressee()
               , "Addressee doesn't correspond to expected");
               // Assert.AreEqual(subjectValue, mailBoxPage.subjectActual)
               //      , "Subject doesn't correspond to expected");
                Assert.AreEqual(bodyValue, mailBoxPage.GetSavedMessageBody()
                    , "Body doesn't correspond to expected");
            });
            mailBoxPage.SendMessage();
            Assert.IsFalse(mailBoxPage.IsElementDisplayed(mailBoxPage.GetLetter())
               , "Letter is not removed from draft folder");
            menuPanel.OpenSentFolder();
            Assert.IsTrue(mailBoxPage.IsElementDisplayed(mailBoxPage.GetLetter())
                , "Letter is absent in send folder");
        }

        [Test]
        public void LogoutTest()
        {
            loginPage = new LoginPage();
            logOutPage = new LogOutPage();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            mailBoxPage.ClickUserIcon()
                 .ClickSignOut();
            Assert.IsTrue(logOutPage.IsElementDisplayed(logOutPage.GetSignedOutText()), "You are not logged off");           
        }

        //Javascript executor
        [Test]
        public void HighlightTest()
        {
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenDraftsFolder();
            Thread.Sleep(5000);
            menuPanel.OpenSentFolder();
            Thread.Sleep(5000);
            //Assert.AreEqual(urlSent, );
        }

        //Actions with mouse
        [Test]
        public void DeleteLetterByHoverTest()
        {
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenNewMessageForm();
            mailBoxPage
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft();
            menuPanel.OpenDraftsFolder();
            Thread.Sleep(3000);
            mailBoxPage.HoverLetter();
            mailBoxPage.JsClickDeleteLetter();
            Thread.Sleep(5000);
            Assert.IsFalse(mailBoxPage.IsElementDisplayed(mailBoxPage.GetLetter())
               ,"Letter is not removed from draft folder");
        }

        //Test with Driver actions class Mouse
        [Test]
        public void DragAndDropToStarredTest()
        {
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            menuPanel = new MenuPanel();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            menuPanel.OpenNewMessageForm();
            mailBoxPage
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft();
            menuPanel.OpenDraftsFolder();
            mailBoxPage.DragAndDropToStarred();
            Assert.IsTrue(mailBoxPage.IsElementDisplayed(starIconActive), "Draft is not saved");
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
            menuPanel.OpenNewMessageForm();
            mailBoxPage
                .FillNewMessageFields(addresseeValue, subjectValue, bodyValue)
                .SaveDraft();
            menuPanel.OpenDraftsFolder();
            mailBoxPage.RightClickLetterAndDelete();
            Thread.Sleep(5000);
            Assert.IsFalse(mailBoxPage.IsElementDisplayed(mailBoxPage.GetLetter()), "Draft is not saved");
        }
    }
}