using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Module7_TAM
{
    [TestFixture]
    class MailBoxTests : BaseTest
    {
        private string password = "H98kS_02b";
        private string email = "june.t14352@gmail.com";
        private string addresseeValue = "tatiana95.77@gmail.com";
        private string subjectValue = "For test";
        private string bodyValue = "This is test email";
        LoginPage loginPage;
        MailBoxPage mailBoxPage;
        LogOutPage logOutPage;

        [Test]       
        public void LoginTest()
        {
            loginPage = new LoginPage(driver);
            mailBoxPage = new MailBoxPage(driver);
            loginPage.LogIn(email, password);
            mailBoxPage.ClickUserIcon();
            Assert.AreEqual(email, mailBoxPage.GetActualEmail()
              , "Login is unsuccessful");                                          
        }

        [Test]
        public void CreateDraftEmailAndSendTest()
        {        
            loginPage.LogIn(email, password);
            mailBoxPage.OpenNewMessageForm();
            mailBoxPage.FillNewMessageFields(addresseeValue, subjectValue, bodyValue);
            mailBoxPage.SaveDraft();
            mailBoxPage.OpenDraftFolder();
            Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter()), "Draft is not saved");
            mailBoxPage.OpenMessage();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(addresseeValue, mailBoxPage.GetSavedMessageAddressee()
               , "Addressee doesn't correspond to expected");
                //Assert.AreEqual(subjectValue, mailBoxPage.subjectActual)
                //     , "Subject doesn't correspond to expected");
                Assert.AreEqual(bodyValue, mailBoxPage.GetSavedMessageBody()
                    , "Body doesn't correspond to expected");
            });
            mailBoxPage.SendMessage();
            Assert.IsFalse(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter())
               , "Letter is not removed from draft folder");
            mailBoxPage.OpenSendFolder();
            Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.GetLetter())
                , "Letter is absent in send folder");
        }

        [Test]
        public void LogoutTest()
        {
            loginPage = new LoginPage(driver);
            mailBoxPage = new MailBoxPage(driver);
            logOutPage = new LogOutPage(driver);
            loginPage.LogIn(email, password);
            mailBoxPage.ClickUserIcon();
            mailBoxPage.ClickSignOut();
            Assert.IsTrue(logOutPage.isElementDisplayed(logOutPage.GetSignedOutText()), "You are not logged off");           
        }
    }
}