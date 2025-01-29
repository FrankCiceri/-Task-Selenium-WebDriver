using OpenQA.Selenium.Support.UI;
using Task__Selenium_WebDriver.DriverUtils;

namespace Task__Selenium_WebDriver.PageObjects
{
    public partial class HeaderPage
    {
        private readonly DriverManager driverManager;
        private WebDriverWait shortWait;
        private WebDriverWait longWait;
    }
}
