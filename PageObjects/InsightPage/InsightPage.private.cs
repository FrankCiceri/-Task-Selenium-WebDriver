using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.DriverUtils;


namespace Selenium_WebDriver.PageObjects.InsightPage
{
    public partial class InsightPage
    {
        private readonly DriverManager driverManager;
        private WebDriverWait shortWait;
        private WebDriverWait longWait;

        private IWebElement WaitCarouselToBeClickable()
        {
            this.shortWait.WaitUntilElementIsVisible(this.insightCarouselCurrentActiveBy);
            return this.shortWait.WaitUntilElementIsClickable(this.insightCarouselCurrentActiveBy);
        }
    }
}
