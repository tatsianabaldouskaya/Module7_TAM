using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
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
                case BrowserType.remoteFirefox:
                    {
                        FirefoxOptions options = new FirefoxOptions();
                        var browserName =  options.BrowserName;
                        options.AddArguments();
                        //options.AddAdditionalCapability("firefox", CapabilityType.BrowserName);
                        //options.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
                        break;
                    }
                case BrowserType.remoteChrome:
                    {
                        ChromeOptions options = new ChromeOptions();
                        //options.AddAdditionalCapability(CapabilityType.BrowserName, "chrome");
                        //options.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                        driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
                        break;
                    }
            }
            return driver;
        }
    }
}
