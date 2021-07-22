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
        public IWebElement draftsFolder;
        
        
        public MailBoxPage OpenDraftsFolder()
        {
            WaitForIsVisible(draftsFolder).Click();          
            return new MailBoxPage();
        }
        //public MenuPanel HighlightDraftsFolder()
        //{
        //    IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
        //    var folder = new Folder();
        //    WaitForIsVisible(draftsFolder).Click();
        //    if (folder.CheckCurrentState(draftsFolder) == FolderState.Unhighlighted)
        //    {
        //        js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", draftsFolder);
        //        folder.CheckCurrentState(draftsFolder);
        //    }
        //    else
        //    {
        //        System.Console.WriteLine("Folder is already highlighted");
        //    }
        //    return this;
        //}
        //public MenuPanel HighlightSentFolder()
        //{
        //    IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
        //    var folder = new Folder();
        //    WaitForIsVisible(sentFolder).Click();
        //    if (folder.CheckCurrentState(sentFolder) == FolderState.Unhighlighted)
        //    {
        //        js.ExecuteScript("arguments[0].style.backgroundColor = '" + "white" + "'", draftsFolder);
        //        js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", sentFolder);
        //    }
        //    else
        //    {
        //        System.Console.WriteLine("Folder is already highlighted");
        //    }
        //    return this;
        //}

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
