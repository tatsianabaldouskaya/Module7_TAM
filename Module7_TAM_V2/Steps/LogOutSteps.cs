using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Module7_TAM_V2.Steps
{
    [Binding]
    public sealed class LogOutSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
       
        private MailBoxPage mailBoxPage = new MailBoxPage();
        private LogOutPage logOutPage = new LogOutPage();

        [When(@"I click user icon")]
        public void ClickUserIcon()
        {
            mailBoxPage.ClickUserIcon();
        }

        [When(@"I click Sign out button")]
        public void ClickSignOut()
        {
            mailBoxPage.ClickSignOut();
        }

        [Then(@"Signed out text is displayed")]
        public void SignedOutTextIsDisplayed()
        {
            Assert.IsTrue(logOutPage.IsSignedOutTextDisplayed(), "You are not logged off");
        }
    }
}
