using Module7_TAM_V2.WebDriver;
using OpenQA.Selenium;

namespace Module7_TAM_V2.States
{
    public class HighlightedState : State
    {
        public HighlightedState(State state)
        {
            this.folderD = state.FolderD;
            level = 1;
        }

        public override void Highlight(IWebElement element)
        {
            level = 1;
            IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
            StateChangeCheck();
        }

        public override void UnHighlight(IWebElement element)
        {
            level = 0;
            IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "white" + "'", element);
            StateChangeCheck();
        }


        private void StateChangeCheck()
        {
            switch (level)
            {
                case 0:
                    folderD.State = new HighlightedState(this);
                    break;
                case 1:
                    folderD.State = new UnhighlightedState(this);
                    break;                
            }
        }
    }
}
