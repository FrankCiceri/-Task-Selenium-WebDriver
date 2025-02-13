using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.Interfaces
{
    public interface IWaitFactory
    {
        WebDriverWait CreateShortWait(IWebDriver driver);

        WebDriverWait CreateLongWait(IWebDriver driver);
    }
}
