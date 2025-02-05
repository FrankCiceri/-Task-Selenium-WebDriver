using OpenQA.Selenium;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Business.PageObjects.InsightPage
{
    public partial class InsightPage
    {
        private readonly IDriverContext _driverContext;

        private void ClickNextSlideButton()
        {
            try
            {
                _driverContext.ShortWait.WaitUntilElementIsClickable(_nextCarouselSlideBy);

                FirstCarouselNextSlideButton.Click();

                LoggerUtil.Info("Clicked on Next Slide button in the carousel.");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to click on Next Slide button in the carousel.", ex);
                throw;
            }
        }
    }
}
