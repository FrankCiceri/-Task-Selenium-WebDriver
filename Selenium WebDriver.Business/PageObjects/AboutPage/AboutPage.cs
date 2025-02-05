using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Utils;

namespace Selenium_WebDriver.Business.PageObjects.AboutPage
{
    public partial class AboutPage
    {
        public AboutPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this._driverContext = driverContext;
        }

        public void ScrollToAtAGlance()
        {
            try
            {
                _driverContext.LongWait.WaitUntilElementExists(this._aboutEpamAtAGlanceBy);
                _driverContext.ScrollToElement(AboutEpamAtAGlanceText);
                LoggerUtil.Info("Scrolled to Epam At a Glance text");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Scroll to the At a Glance Section", _aboutEpamAtAGlanceBy, ex);

                throw;
            }
        }

        public void ClickDownloadButton()
        {
            try
            {
                _driverContext.LongWait.WaitUntilElementIsClickable(_aboutAtAGlanceDownloadButtonBy);
                AboutAtAGlanceDownloadButton.Click();
                LoggerUtil.Info("Download button clicked");
            }
            catch (Exception ex)
            {
                LoggerUtil.Error("Failed to Click At A Glance Download Button", _aboutAtAGlanceDownloadButtonBy, ex);

                throw;
            }
        }
    }
}
