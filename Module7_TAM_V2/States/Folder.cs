using Module7_TAM_V2.WebDriver;
using OpenQA.Selenium;
using System;



namespace Module7_TAM_V2.States
{   
    public class Folder
    {
        private FolderState state;

        public FolderState CheckCurrentState(IWebElement element)
        {
            return state = (element.GetCssValue("background-color") == "rgba(255, 255, 0, 1)") ? FolderState.Highlighted : FolderState.Unhighlighted;
        }

        public FolderState HighlightFolder(IWebElement element)
        {
            IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;
            
            if (CheckCurrentState(element) == FolderState.Unhighlighted)
            {
                js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
            }

                return FolderState.Highlighted;
        }

        public FolderState UnhighlightFolder(IWebElement element)
        {
            IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;

            if (CheckCurrentState(element) == FolderState.Highlighted)
            {
                js.ExecuteScript("arguments[0].style.backgroundColor = '" + "white" + "'", element);
            }

               return FolderState.Unhighlighted;
            
        }
    }
}

