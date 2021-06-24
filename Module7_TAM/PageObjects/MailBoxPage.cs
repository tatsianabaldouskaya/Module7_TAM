using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace Module7_TAM
{
    class MailBoxPage:AbstractPage
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
        public readonly By actualEmail = By.XPath("//div[@class='gb_nb']");
        public readonly By letter = By.XPath("//span/span[text() = 'For test']");
        public readonly By addresseeActual = By.CssSelector("div.oL>span[email]");
        public readonly By subjectActual = By.XPath("//input[@name = 'subjectbox']");
        public readonly By bodyActual = By.CssSelector("div.editable");


        public MailBoxPage(IWebDriver driver) : base(driver) { }
        public void ClickUserIcon()
        {
            WaitForIsVisible(userIcon);
            Click(userIcon);
        }
        public void OpenSendFolder()
        {
            Click(sendFolder);
        }
        public void OpenDraftFolder()
        {
            Click(draftFolder);
        }
        public void OpenNewMessageForm()
        {
            Click(newMessageButton);
        }
        public void FillNewMessageFields(string addresseeValue, string subjectValue, string bodyValue)
        {
            SendKeys(addresseeField, addresseeValue);
            SendKeys(subjectField, subjectValue);
            SendKeys(bodyField, bodyValue);
        }
        public void SaveDraft()
        {
            Click(closeMessageButton);
        }
        public void OpenMessage()
        {
            WaitForIsVisible(letter);
            Click(letter);
        }
        public void SendMessage()
        {
            Click(sendButton);
        }
        public void ClickSignOut()
        {
            WaitForIsVisible(signOutButton);
            Click(signOutButton);
        }
    }
}
