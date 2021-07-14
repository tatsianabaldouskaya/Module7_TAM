using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Collections.Specialized;

namespace Module8_TAM
{
    [TestFixture]
    class MailBoxTests : BaseTest
    {
        private string email = ConfigurationManager.AppSettings["email"];
        private string password = ConfigurationManager.AppSettings["password"];
        private string addresseeValue = "tatiana95.77@gmail.com";
        private string subjectValue = "For test";
        private string bodyValue = "This is test email";
        LoginPage loginPage;
        MailBoxPage mailBoxPage;
        MenuPanel menuPanel;
        LogOutPage logOutPage;

        [Test]
        public void LoginTest()
        {
            loginPage = new LoginPage();
            mailBoxPage = new MailBoxPage();
            loginPage
                .EnterEmail(email)
                .ClickNext()
                .EnterPassword(password)
                .ClickNext();
            mailBoxPage
                .ClickUserIcon();
            Assert.AreEqual(email, mailBoxPage.GetActualEmail()
              , "Login is unsuccessful");
        }

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
          //  Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter()), "Draft is not saved");
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
           // Assert.IsFalse(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter())
           //    , "Letter is not removed from draft folder");
            menuPanel.OpenSentFolder();
         //   Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter())
            //    , "Letter is absent in send folder");
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
           // Assert.IsTrue(logOutPage.isElementDisplayed(logOutPage.GetSignedOutText()), "You are not logged off");
        }
    }
}