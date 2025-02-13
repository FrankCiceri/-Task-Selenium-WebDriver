using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.Interfaces
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver(string downloadDirectory = "C:\\Downloads");
    }
}
