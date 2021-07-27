using OpenQA.Selenium;

namespace Module7_TAM_V2.States
{
    public class FolderD
    {
        private State state;

        public FolderD()
        {
            this.state = new UnhighlightedState(this);
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }

        public void HighLight(IWebElement element)
        {
            state.Highlight(element);
        }

        public void UnHighlight(IWebElement element)
        {
            state.UnHighlight(element);
        }

        public bool CheckCurrentState(IWebElement element)
        {
            return element.GetCssValue("background-color") == "rgba(255, 255, 0, 1)";
        }
    }
}
