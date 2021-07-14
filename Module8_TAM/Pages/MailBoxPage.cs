using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Module8_TAM.WebDriver;

namespace Module8_TAM
{
    public class MailBoxPage : AbstractPage
    {
        private IWebElement userIcon = Browser.GetDriver().FindElement(By.XPath("//img[@class='gb_Ca gbii']"));
        private IWebElement newMessageButton = Browser.GetDriver().FindElement(By.XPath("//div[@class='T-I T-I-KE L3']"));
        private IWebElement addresseeField = Browser.GetDriver().FindElement(By.Name("to"));
        private IWebElement subjectField = Browser.GetDriver().FindElement(By.Name("subjectbox"));
        private IWebElement bodyField = Browser.GetDriver().FindElement(By.CssSelector("div.editable"));
        private IWebElement sendButton = Browser.GetDriver().FindElement(By.CssSelector("div[data-tooltip^='Send']"));
        private IWebElement sendFolder = Browser.GetDriver().FindElement(By.XPath("//a[contains(@href,'#sent')]"));
        private IWebElement draftFolder = Browser.GetDriver().FindElement(By.LinkText("Drafts"));
        private IWebElement signOutButton = Browser.GetDriver().FindElement(By.XPath("//a[text()= 'Sign out']"));
        private IWebElement closeMessageButton = Browser.GetDriver().FindElement(By.XPath("//img[@alt ='Close']"));
        private IWebElement actualEmail = Browser.GetDriver().FindElement(By.XPath("//div[@class='gb_nb']"));
        private IWebElement letter = Browser.GetDriver().FindElement(By.XPath("//span/span[text() = 'For test']"));
        private IWebElement addresseeActual = Browser.GetDriver().FindElement(By.CssSelector("div.oL>span[email]"));
        private By subjectActual = By.XPath("//input[@name = 'subjectbox']");
        private IWebElement bodyActual = Browser.GetDriver().FindElement(By.CssSelector("div.editable"));

        public MailBoxPage() : base(Browser.GetDriver()) { }
        public MailBoxPage ClickUserIcon()
        {
            WaitForIsVisible(userIcon).Click();
            return this;
        }
        public string GetActualEmail()
        {
            return actualEmail.Text;
        }
        public MailBoxPage FillNewMessageFields(string addresseeValue, string subjectValue, string bodyValue)
        {
            addresseeField.SendKeys(addresseeValue);
            subjectField.SendKeys(subjectValue);
            bodyField.SendKeys(bodyValue);
            return this;
        }
        public MailBoxPage SaveDraft()
        {
            closeMessageButton.Click();
            return this;
        }
        public IWebElement GetLetter()
        {
            return letter;
        }
        public string GetSavedMessageAddressee()
        {
            WaitForIsVisible(addresseeActual);
            return addresseeActual.Text;
        }
        public string GetSavedMessageBody()
        {
            WaitForIsVisible(bodyActual);
            return bodyActual.Text;
        }
        public MailBoxPage OpenMessage()
        {
            WaitForIsVisible(letter).Click();
            return this;
        }
        public MailBoxPage SendMessage()
        {
            sendButton.Click();
            return this;
        }
        public LogOutPage ClickSignOut()
        {
            WaitForIsVisible(signOutButton).Click();
            return new LogOutPage();
        }
    }
}
