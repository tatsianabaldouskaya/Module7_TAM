using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Module7_TAM.PageObjects;
using System.Configuration;
using System.Collections.Specialized;

namespace Module7_TAM
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
            mailBoxPage = loginPage
                .LogIn(email, password)
                .ClickUserIcon();
            Assert.AreEqual(email, mailBoxPage.GetActualEmail()
              , "Login is unsuccessful");                                          
        }

        [Test]
        public void CreateDraftEmailAndSendTest()
        {
            loginPage = new LoginPage();        
            mailBoxPage = loginPage.LogIn(email, password).OpenMessage().FillNewMessageFields(addresseeValue, subjectValue, bodyValue).SaveDraft();           
            //Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter()), "Draft is not saved");
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
            //Assert.IsFalse(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter())
              // , "Letter is not removed from draft folder");
            menuPanel.OpenSentFolder();
           // Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter())
                //, "Letter is absent in send folder");
        }

        [Test]
        public void LogoutTest()
        {
            loginPage = new LoginPage();
            logOutPage = loginPage
                .LogIn(email, password)
                .ClickUserIcon()
                .ClickSignOut();
            Assert.IsTrue(logOutPage.IsSignedOutTextDisplayed(), "You are not logged off");           
        }
    }
}