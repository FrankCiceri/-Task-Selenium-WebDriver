using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.Core
{
    internal static class DriverHeadless
    {
        internal static string GetChromeParameter()
        {
            return "--headless= new";
        }

        internal static string GetEdgeParameter()
        {
            return "--headless";
        }

        internal static string GetFirefoxParameter()
        {
            return "--headless";
        }
    }
}
