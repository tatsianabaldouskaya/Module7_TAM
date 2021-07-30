using OpenQA.Selenium;
using System;
using System.Threading;

namespace Module7_TAM_V2.WebDriver
{
    public class Browser
    {
        private static Browser currentInstance;
        // private static IWebDriver driver;
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public static BrowserFactory.BrowserType CurrentBrowser;
        private static string browser;

        private Browser()
        {
            browser = Configuration.Browser;
            Enum.TryParse(browser, out CurrentBrowser);
            driver.Value = BrowserFactory.GetDriver(CurrentBrowser, 10);
        }
        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }
        public static Browser Instance => currentInstance ?? (currentInstance = new Browser());
        public static void CloseDriver()
        {
            GetDriver().Quit();
            driver.Value = null;
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
