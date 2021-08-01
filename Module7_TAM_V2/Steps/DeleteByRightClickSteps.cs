using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Module7_TAM_V2.Steps
{
    [Binding]
    public sealed class DeleteByRightClickSteps
    {
        private MailBoxPage mailBoxPage = new MailBoxPage();

        private readonly ScenarioContext _scenarioContext;

        public DeleteByRightClickSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I do rightclick on the letter")]
        public void DoRightclickOnTheLetter()
        {
            mailBoxPage.RightClickLetter();
        }

        [When(@"I select delete option")]
        public void SelectDeleteOption()
        {
            mailBoxPage.SelectDeleteThroughRightClick();
        }

    }
}
