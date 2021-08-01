using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Module7_TAM_V2.Steps
{
    [Binding]
    public sealed class CreateMessageSteps
    {
        private MailBoxPage mailBoxPage = new MailBoxPage();
        private MenuPanel menuPanel = new MenuPanel();

        [Given(@"I click composeButton")]
        public void ClickComposeButton()
        {
            menuPanel.OpenNewMessageForm();
        }

        [When(@"I enter '(.*)' to addresseeField")]
        public void EnterAddressee(string addressee)
        {
            mailBoxPage.FillAddressee(addressee);
        }

        [When(@"I enter '(.*)' to subjectField")]
        public void EnterToSubject(string subject)
        {
            mailBoxPage.FillSubject(subject);
        }

        [When(@"I enter '([a-z]{5}[_][1-9]{2}[abc])' to bodyField")]
        public void EnterBody(string body)
        {
            mailBoxPage.FillBody(body);
        }

        [When(@"I click closeIcon")]
        public void ClickCloseIcon()
        {
            mailBoxPage.SaveDraft();
        }

        [When(@"I open drafts folder")]
        public void OpenDraftsFolder()
        {
            menuPanel.OpenDraftsFolder();
        }

        [Then(@"letter is displayed in drafts folder")]
        public void LetterIsDisplayedInDraftsFolder()
        {
            Assert.IsTrue(mailBoxPage.IsLetterDisplayed());
        }

        [AfterScenario("Create message")]
        public void CleanFolder()
        {
            mailBoxPage.HoverLetter();
            mailBoxPage.JsClickDeleteLetter();
        }
    }
}
