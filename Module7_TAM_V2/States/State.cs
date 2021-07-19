using Module7_TAM_V2.WebDriver;
using OpenQA.Selenium;
using System;



namespace Module7_TAM_V2.States
{
   public enum FolderState
    {
        Highlighted,
        Unhighlighted
    }
    public class Folder
    {
        public FolderState State { get; set; }
        public Folder(FolderState state)
        {
            State = state;
        }
        IJavaScriptExecutor js = Browser.GetDriver() as IJavaScriptExecutor;

        public void JavaScriptHighlight(IWebElement element)
        {
           
            if (element.GetCssValue("background-color") != "rgba(255, 255, 0, 1)")
            {
                js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
                State = FolderState.Highlighted;
            }
            else
            {
                Console.WriteLine("Folder is already highlighted");
                State = FolderState.Highlighted;
            }
        }

        public void JavaScriptUnhighlight(IWebElement element)
        {
            if (element.GetCssValue("background-color") != "rgba(255, 255, 0, 1)")
            {
                js.ExecuteScript("arguments[0].style.backgroundColor = '" + "white" + "'", element);
                State = FolderState.Unhighlighted;
            }
            else
            {
                Console.WriteLine("Folder is not highlighted");
                State = FolderState.Unhighlighted;
            }
        }
    }
}

