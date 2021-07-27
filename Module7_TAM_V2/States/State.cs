using OpenQA.Selenium;

namespace Module7_TAM_V2.States
{
    public abstract class State
    {
        protected FolderD folderD;
        protected int level;

        public FolderD FolderD
        {
            get { return folderD; }
            set { folderD = value; }
        }

        public abstract void Highlight(IWebElement element);
        public abstract void UnHighlight(IWebElement element);
    }
}
