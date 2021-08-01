using Module7_TAM_V2.States;
using Module7_TAM_V2.WebDriver;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Module7_TAM_V2
{
    public class MenuPanel:AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='T-I T-I-KE L3']")]
        private IWebElement composeButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'#inbox')]")]
        private IWebElement inboxFolder;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'#snoozed')]")]
        private IWebElement snoozedFolder;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'#sent')]")]
        public IWebElement sentFolder;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'#drafts')]")]
        private IWebElement draftsFolder;
        
        
        public void OpenDraftsFolder()
        {
            WaitForIsVisible(draftsFolder).Click();          
        }

        public IWebElement GetDraftsFolder()
        {
            WaitForIsVisible(draftsFolder);
            return draftsFolder;
        }

        public IWebElement GetSentFolder()
        {
            WaitForIsVisible(sentFolder);
            return sentFolder;
        }

        public MailBoxPage GoToMailBox()
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

        public MailBoxPage OpenInboxFolder()
        {
            WaitForIsVisible(inboxFolder).Click();
            return new MailBoxPage();
        }
    }
}
