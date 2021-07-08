using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.WebDriver
{
    public class Browser
    {
        private static Browser currentInstance;
        private static IWebDriver driver;
        public static BrowserFactory.BrowserType CurrentBrowser;
        private static string browser;

        private Browser()
        {
            browser = Configuration.Browser;
            Enum.TryParse(browser, out CurrentBrowser);
            driver = BrowserFactory.GetDriver(CurrentBrowser, 10);
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }
        public static Browser Instance => currentInstance ?? (currentInstance = new Browser());
        public static void CloseDriver()
        {
            GetDriver().Quit();
            driver = null;
            currentInstance = null;
            browser = null;
        }
        public static void OpenStartPage(String baseUrl)
        {
            GetDriver().Manage().Window.Maximize();
            GetDriver().Navigate().GoToUrl(baseUrl);
        }
    }
}
