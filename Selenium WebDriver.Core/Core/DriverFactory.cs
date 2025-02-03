using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.Core
{
    public class DriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver(string downloadDirectory = "C:\\Downloads")
        {
            var browser = "chrome";
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    return new ChromeDriver(chromeOptions);
                default:
                    throw new NotSupportedException($"Unsupported browser: {browser}");
            }
        }
    }
}
