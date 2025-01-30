using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.DriverUtils;

namespace Selenium_WebDriver.PageObjects
{
    public partial class HeaderPage
    {
        private readonly DriverManager driverManager;
        private WebDriverWait shortWait;
        private WebDriverWait longWait;
    }
}
