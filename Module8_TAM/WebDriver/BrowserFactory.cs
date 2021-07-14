using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8_TAM.WebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            FireFox
        }

        public static IWebDriver GetDriver(BrowserType type)
        {
            IWebDriver driver = null;
            switch (type)
            {
                case BrowserType.Chrome:
                {
                   var service = ChromeDriverService.CreateDefaultService();
                   var option = new ChromeOptions();
                   //скрывать всплывающие окна
                   option.AddArgument("disable-infobars");
                   //время ожидания браузера
                   driver = new ChromeDriver(service, option);
                   break;
                }
                case BrowserType.FireFox:
                {
                   var service = FirefoxDriverService.CreateDefaultService();
                   var option = new FirefoxOptions();
                   option.AddArgument("disable-infobars");
                   driver = new FirefoxDriver(service, option);
                   break;
                }
            }
            return driver;
        }
    }
}
