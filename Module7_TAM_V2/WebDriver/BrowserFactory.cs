using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace Module7_TAM_V2.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            Edge,
            remoteChrome,
            remoteFirefox          
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;
            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var option = new FirefoxOptions();
                        option.AddArgument("disable-infobars");
                        driver = new FirefoxDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Edge:
                    {
                        var service = EdgeDriverService.CreateDefaultService("C:\\Users\\Tatsiana_Baldouskaya\\source\\repos\\Module7_TAM\\Module7_TAM_V2\\bin\\Debug", @"msedgedriver.exe");
                        var option = new EdgeOptions();
                        option.AddExtensionPaths("binary", @"C:\\Program Files(x86)\\Microsoft\\Edge\\Application\\msedge.exe");
                        driver = new EdgeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.remoteFirefox:
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        var browserName =  options.BrowserName;
                        options.AddArguments();
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
                        break;
                    }
                case BrowserType.remoteChrome:
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--no-sandbox");
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
                        break;
                    }
            }
            return driver;
        }
    }
}
