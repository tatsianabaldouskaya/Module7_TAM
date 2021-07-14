using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using Module7_TAM_V2.WebDriver;
using Module7_TAM_V2.Model;

namespace Module7_TAM_V2
{
    public class MailBoxPage : AbstractPage
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

        [FindsBy(How = How.XPath, Using = "//input[@name = 'subject']")]
        private IWebElement subjectActual;

        [FindsBy(How = How.CssSelector, Using = "div.editable")]
        private IWebElement bodyActual;

        [FindsBy(How = How.XPath,
            Using = "//div[@class = 'BltHke nH oy8Mbf']//ul[@role = 'toolbar']/li[@data-tooltip = 'Delete']")]
        private IWebElement deleteLetterOnHover;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'#starred')]")]
        private IWebElement starredFolder;

        [FindsBy(How = How.XPath, Using = "//span[@aria-label = 'Starred']")]
        public IWebElement starIconActive;

        public MailBoxPage ClickUserIcon()
        {
            WaitForIsVisible(userIcon).Click();
            return this;
        }

        public string GetActualEmail()
        {
            return actualEmail.Text;
        }

        public string GetActualSubject() => subjectActual.GetAttribute("value");
        
        public MailBoxPage FillNewMessageFields(Message message)
        {
            WaitForIsVisible(addresseeField).SendKeys(message.addresseeValue);
            subjectField.SendKeys(message.subjectValue);
            bodyField.SendKeys(message.bodyValue);
            return this;
        }
        public MenuPanel SaveDraft()
        {
            closeMessageButton.Click();
            return new MenuPanel();
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
            JavaScriptHighlight(sendButton);
            sendButton.Click();
            return this;
        }
        public LogOutPage ClickSignOut()
        {
            WaitForIsVisible(signOutButton).Click();
            return new LogOutPage();
        }
        public MailBoxPage HoverLetter()
        {
            WaitForIsVisible(letter);
            new Actions(Browser.GetDriver()).MoveToElement(letter).Build().Perform();
            return this;
        }
        public void JsClickDeleteLetter()
        {
            JavaScriptClick(deleteLetterOnHover);
        }
        public MailBoxPage DragAndDropToStarred()
        {
            WaitForIsVisible(letter);
            Actions builder = new Actions(Browser.GetDriver());
            builder.DragAndDrop(letter, starredFolder).Perform();
            return this;
        }
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
        public bool IsLetterDisplayed()
        {
            return IsElementDisplayed(letter);
        }
        public bool IsStarIconActive()
        {
            return IsElementDisplayed(starIconActive);
        }
    }
}
