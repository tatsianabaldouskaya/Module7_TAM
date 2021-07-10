using System.Configuration;

namespace Module7_TAM_V2.WebDriver
{
    public class Configuration
    {
        public static string Browser => ConfigurationManager.AppSettings["Browser"] ?? "Firefox";
    }
}
