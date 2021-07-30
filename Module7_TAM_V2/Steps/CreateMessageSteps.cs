using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Module7_TAM_V2.Steps
{
    [Binding]
    public sealed class CreateMessageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CreateMessageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I click composeButton")]
        public void WhenIClickComposeButton()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter '(.*)' to addresseeField")]
        public void WhenIEnterToAddresseeField(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter '(.*)' to subjectField")]
        public void WhenIEnterToSubjectField(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter '(.*)' to bodyField")]
        public void WhenIEnterToBodyField(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click closeIcon")]
        public void WhenIClickCloseIcon()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I open drafts folder")]
        public void WhenIOpenDraftsFolder()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"letter is displayed in drafts folder")]
        public void ThenLetterIsDisplayedInDraftsFolder()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
