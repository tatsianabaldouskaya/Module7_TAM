using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_TAM_V2.Utils
{
    public static class Logger
    {
        public static ILog Log { get; } = LogManager.GetLogger("Logger");
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
