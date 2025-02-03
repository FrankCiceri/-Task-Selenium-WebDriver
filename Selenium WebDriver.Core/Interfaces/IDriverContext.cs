using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.Interfaces
{
    public interface IDriverContext
    {
        WebDriverWait ShortWait { get; }

        WebDriverWait LongWait { get; }

        IWebDriver GetDriver();

        static IDriverContext Instance { get; }

        void GoToUrl(string url);

        void ReleaseDriver();
    }
}
