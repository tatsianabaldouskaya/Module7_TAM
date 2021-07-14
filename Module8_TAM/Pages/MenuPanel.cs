using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module8_TAM.WebDriver;
using OpenQA.Selenium;

namespace Module8_TAM
{
    public class MenuPanel : AbstractPage
    {
        private IWebElement composeButton = Browser.GetDriver().FindElement(By.XPath("//div[@class='T-I T-I-KE L3']"));
        private IWebElement inboxFolder = Browser.GetDriver().FindElement(By.XPath("//a[contains(@href,'#inbox')]"));
        private IWebElement starredFolder = Browser.GetDriver().FindElement(By.XPath("//a[contains(@href,'#starred')]"));
        private IWebElement snoozedFolder = Browser.GetDriver().FindElement(By.XPath("//a[contains(@href,'#snoozed')]"));
        private IWebElement sentFolder = Browser.GetDriver().FindElement(By.XPath("//a[contains(@href,'#sent')]"));
        private IWebElement draftsFolder = Browser.GetDriver().FindElement(By.XPath("//a[contains(@href,'#drafts')]"));

        public MenuPanel() : base(Browser.GetDriver()) { }
        public MailBoxPage OpenDraftsFolder()
        {
            WaitForIsVisible(draftsFolder).Click();
            return new MailBoxPage();
        }
        public MailBoxPage OpenSentFolder()
        {
            WaitForIsVisible(sentFolder).Click();
            return new MailBoxPage();
        }
        public MailBoxPage OpenNewMessageForm()
        {
            WaitForIsVisible(composeButton).Click();
            return new MailBoxPage();
        }
        public MailBoxPage OpenSnoozedFolder()
        {
            WaitForIsVisible(snoozedFolder).Click();
            return new MailBoxPage();
        }
        public MailBoxPage OpenStarredFolder()
        {
            WaitForIsVisible(starredFolder).Click();
            return new MailBoxPage();
        }
        public MailBoxPage OpenInboxFolder()
        {
            WaitForIsVisible(inboxFolder).Click();
            return new MailBoxPage();
        }
    }
}
