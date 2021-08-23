using Module7_TAM_V2.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.Utils
{
    public static class Screenshoter
    {
        public static void GetScreenshot()
        {
            Screenshot screenShot = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            var path = "C:/Users/Tatsiana_Baldouskaya/source/repos/Module7_TAM/";
            screenShot.SaveAsFile(path+"screenshot_"+ timestamp +".png", ScreenshotImageFormat.Png);
            Logger.Log.Info("ScreenShot is saved to "+ path);
        }                 
    }
}
