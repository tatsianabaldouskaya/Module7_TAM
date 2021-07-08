using System;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using Module7_TAM_V2.WebDriver;

namespace Module7_TAM_V2
{
    public class MailBoxPage: AbstractPage
    {
        [FindsBy(How = How.XPath, Using = "//img[@class='gb_Ca gbii']")]
        private IWebElement userIcon;

        [FindsBy(How = How.Name, Using = "to")]
        private IWebElement addresseeField;

        [FindsBy(How = How.Name, Using = "subjectbox")]
        private IWebElement subjectField;

        [FindsBy(How = How.CssSelector, Using = "div.editable")]
        private IWebElement bodyField;

        [FindsBy(How = How.CssSelector, Using = "div[data-tooltip^='Send']")]
        private IWebElement sendButton;

        [FindsBy(How = How.XPath, Using = "//a[text()= 'Sign out']")]
        private IWebElement signOutButton;

        [FindsBy(How = How.XPath, Using = "//img[@alt ='Close']")]
        private IWebElement closeMessageButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='gb_nb']")]
        private IWebElement actualEmail;

        [FindsBy(How = How.XPath, Using = "//span[text() = 'For test']//ancestor-or-self::tr[@class='zA yO']")]
        private IWebElement letter;

        [FindsBy(How = How.CssSelector, Using = "div.oL>span[email]")]
        private IWebElement addresseeActual;

        [FindsBy(How = How.XPath, Using = "//input[@name = 'subjectbox']")]
        private IWebElement subjectActual;

        [FindsBy(How = How.CssSelector, Using = "div.editable")]
        private IWebElement bodyActual;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'BltHke nH oy8Mbf']//ul[@role = 'toolbar']/li[@data-tooltip = 'Delete']")]
        private IWebElement deleteLetterOnHover;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'#starred')]")]
        public IWebElement starredFolder;

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
            JavaScriptHighlight(sendButton);
            return this;
        }
        public LogOutPage ClickSignOut()
        {
            WaitForIsVisible(signOutButton).Click();
            return new LogOutPage();
        }
        public MailBoxPage HoverLetter()
        {
            new Actions(Browser.GetDriver()).MoveToElement(letter).Build().Perform();
            return this;
        }
        public void JsClickDeleteLetter()
        {
            JavaScriptClick(deleteLetterOnHover);
            Thread.Sleep(5000);
        }

        //mouse action
        public MailBoxPage DragAndDropToStarred()
        {
            Actions builder = new Actions(Browser.GetDriver());
            builder.DragAndDrop(letter, starredFolder).Perform();
            return this;
        }

        //action with Keyboard
        public MailBoxPage RightClickLetterAndDelete()
        {
            WaitForIsVisible(letter);
            Actions builder = new Actions(Browser.GetDriver());
            builder.ContextClick(letter).Release()
                .SendKeys(Keys.ArrowDown)
                .SendKeys(Keys.ArrowDown)
                .SendKeys(Keys.Enter)
                .Perform();
            return this;
        }
    }
}
