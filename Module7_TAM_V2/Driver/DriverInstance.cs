using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Firefox;

namespace Module7_TAM_V2
{
    public class DriverInstance
    {
        private static IWebDriver driver;
        private static ThreadLocal<IWebDriver> driverHolder = new ThreadLocal<IWebDriver>();

        private DriverInstance() { }

        public static IWebDriver GetDriver()
        {
            if (driverHolder.Value == null)
            {
                driverHolder.Value = GetNewDriver();
            }
            return driverHolder.Value;
        }
        public static IWebDriver GetNewDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            return driver;
        }
        public static void CloseDriver()
        {
            GetDriver().Quit();
            driverHolder.Value = null;
        }
        public static void OpenStartPage(String baseUrl)
        {
            GetDriver().Manage().Window.Maximize();
            GetDriver().Navigate().GoToUrl(baseUrl);
        }
    }
}
