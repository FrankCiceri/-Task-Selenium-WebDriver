using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.DriverUtils;

namespace Selenium_WebDriver.PageObjects.CareersPage
{
    public partial class CareerPage
    {
        private DriverManager driverManager;
        private WebDriverWait shortWait;
        private WebDriverWait longWait;

        private IWebElement SelectLocation(string location)
        {
            string locationLocator = $"//li[contains(text(), '{location}')]";
            By locationBy = By.XPath(locationLocator);
            return this.shortWait.WaitFindElement(locationBy);
        }
    }
}
