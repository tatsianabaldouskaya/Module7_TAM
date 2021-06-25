using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace Module7_TAM
{
    public class MailBoxPage:AbstractPage
    {
        private readonly By userIcon = By.XPath("//img[@class='gb_Ca gbii']");
        private readonly By newMessageButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By addresseeField = By.Name("to");
        private readonly By subjectField = By.Name("subjectbox");
        private readonly By bodyField = By.CssSelector("div.editable");
        private readonly By sendButton = By.CssSelector("div[data-tooltip^='Send']");
        private readonly By sendFolder = By.XPath("//a[contains(@href,'#sent')]");
        private readonly By draftFolder = By.LinkText("Drafts");
        private readonly By signOutButton = By.XPath("//a[text()= 'Sign out']");
        private readonly By closeMessageButton = By.XPath("//img[@alt ='Close']");
        private readonly By actualEmail = By.XPath("//div[@class='gb_nb']");
        private readonly By letter = By.XPath("//span/span[text() = 'For test']");
        private readonly By addresseeActual = By.CssSelector("div.oL>span[email]");
        private readonly By subjectActual = By.XPath("//input[@name = 'subjectbox']");
        private readonly By bodyActual = By.CssSelector("div.editable");


        public MailBoxPage(IWebDriver driver) : base(driver) { }
        public MailBoxPage ClickUserIcon()
        {
            WaitForIsVisible(userIcon);
            Click(userIcon);
            return this;
        }
        public By GetActualEmail()
        {
            return actualEmail;
        }
        public MailBoxPage OpenSendFolder()
        {
            Click(sendFolder);
            return this;
        }
        public MailBoxPage OpenDraftFolder()
        {
            Click(draftFolder);
            return this;
        }
        public MailBoxPage OpenNewMessageForm()
        {
            Click(newMessageButton);
            return this;
        }
        public MailBoxPage FillNewMessageFields(string addresseeValue, string subjectValue, string bodyValue)
        {
            SendKeys(addresseeField, addresseeValue);
            SendKeys(subjectField, subjectValue);
            SendKeys(bodyField, bodyValue);
            return this;
        }       
        public MailBoxPage SaveDraft()
        {
            Click(closeMessageButton);
            return this;
        }
        public By GetLetter()
        {
            return letter;
        }
        public string GetSavedMessageAddressee()
        {
            return driver.FindElement(addresseeActual).Text;
        }
        public string GetSavedMessageBody()
        {
            return driver.FindElement(bodyActual).Text;
        }
        public MailBoxPage OpenMessage()
        {
            WaitForIsVisible(letter);
            Click(letter);
            return this;
        }
        public MailBoxPage SendMessage()
        {
            Click(sendButton);
            return this;
        }
        public LogOutPage ClickSignOut()
        {
            WaitForIsVisible(signOutButton);
            Click(signOutButton);
            return new LogOutPage(driver);
        }
    }
}
