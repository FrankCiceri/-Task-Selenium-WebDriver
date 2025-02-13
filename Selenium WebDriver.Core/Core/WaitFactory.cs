using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Selenium_WebDriver.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.Core
{
    public class WaitFactory: IWaitFactory
    {
        public WebDriverWait CreateShortWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(3))
            {
                PollingInterval = TimeSpan.FromSeconds(0.25),
            };
        }

        public WebDriverWait CreateLongWait(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(20))
            {
                PollingInterval = TimeSpan.FromSeconds(0.5),
            };
        }
    }
}
