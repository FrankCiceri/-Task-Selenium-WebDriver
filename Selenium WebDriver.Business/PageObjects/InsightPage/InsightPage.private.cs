using OpenQA.Selenium;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.InsightPage
{
    public partial class InsightPage
    {
        private readonly IDriverContext driverContext;

        private IWebElement WaitCarouselToBeClickable()
        {
            this.driverContext.ShortWait.WaitUntilElementIsVisible(this.insightCarouselCurrentActiveBy);
            return this.driverContext.ShortWait.WaitUntilElementIsClickable(this.insightCarouselCurrentActiveBy);
        }
    }
}
