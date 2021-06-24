﻿using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Module7_TAM
{
    [TestFixture]
    class Tests : BaseTest
    {
        private string password = "H98kS_02b";
        private string email = "june.t14352@gmail.com";
        private string addresseeValue = "tatiana95.77@gmail.com";
        private string subjectValue = "For test";
        private string bodyValue = "This is test email";

        [Test]       
        public void LoginTest()
        {     
          LoginPage loginPage = new LoginPage(driver);
          MailBoxPage mailBoxPage = new MailBoxPage(driver);
          loginPage.LogIn(email, password);
          
          mailBoxPage.ClickUserIcon();
          Assert.AreEqual(email, mailBoxPage.GetElementText(mailBoxPage.actualEmail)
              , "Login is unsuccessful");                                          
        }

        [Test]
        public void CreateDraftEmailTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            MailBoxPage mailBoxPage = new MailBoxPage(driver);
            
            loginPage.LogIn(email, password);
            mailBoxPage.OpenNewMessageForm();
            mailBoxPage.FillNewMessageFields(addresseeValue, subjectValue, bodyValue);
            mailBoxPage.SaveDraft();
            mailBoxPage.OpenDraftFolder();
            Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.letter), "Draft is not saved");
            mailBoxPage.OpenMessage();
            Assert.AreEqual(addresseeValue, mailBoxPage.GetElementText(mailBoxPage.addresseeActual)
                , "Addressee doesn't correspond to expected");
            Assert.AreEqual(subjectValue, mailBoxPage.subjectActual)
                 , "Subject doesn't correspond to expected");
            Assert.AreEqual(bodyValue, mailBoxPage.GetElementText(mailBoxPage.bodyActual)
                , "Body doesn't correspond to expected");
        }

        [Test]
        public void SendEmailTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            MailBoxPage mailBoxPage = new MailBoxPage(driver);
            loginPage.LogIn(email, password);
            mailBoxPage.OpenNewMessageForm();
            mailBoxPage.FillNewMessageFields(addresseeValue, subjectValue, bodyValue);
            mailBoxPage.SaveDraft();
            mailBoxPage.OpenDraftFolder();
            mailBoxPage.OpenMessage();
            mailBoxPage.SendMessage();
            Assert.IsFalse(mailBoxPage.isElementDisplayed(mailBoxPage.letter)
                , "Letter is not removed from draft folder");
            mailBoxPage.OpenSendFolder();
            Assert.IsTrue(mailBoxPage.isElementDisplayed(mailBoxPage.letter)
                , "Letter is absent in send folder");
        }

        [Test]
        public void LogoutTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            MailBoxPage mailBoxPage = new MailBoxPage(driver);
            LogOutPage logoutPage = new LogOutPage(driver);
            loginPage.LogIn(email, password);
            mailBoxPage.ClickUserIcon();
            mailBoxPage.ClickSignOut();
            Assert.IsTrue(logoutPage.isElementDisplayed(logoutPage.signedOutText), "You are not logged off");           
        }
    }
}