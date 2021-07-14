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
            Screenshot image = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
            image.SaveAsFile("C:/Users/Tatsiana_Baldouskaya/source/repos/Module7_TAM/image.png", ScreenshotImageFormat.Png);
        }                 
    }
}
