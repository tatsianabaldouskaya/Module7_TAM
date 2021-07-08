using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.WebDriver
{
    public class Configuration
    {
        public static string Browser => ConfigurationManager.AppSettings["Browser"] ?? "Firefox";
    }
}
