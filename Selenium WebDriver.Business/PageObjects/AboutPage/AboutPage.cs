using OpenQA.Selenium;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

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

            this.driverContext = driverContext;
        }

        public void ScrollToAtAGlance()
        {
            var atAGlanceText = this.driverContext.LongWait.WaitUntilElementExists(this.aboutEpamAtAGlanceBy);
            this.driverContext.ScrollToElement(atAGlanceText);
        }

        public void ClickDownloadButton()
        {
            var downloadButton = this.driverContext.LongWait.WaitUntilElementIsClickable(this.aboutAtAGlanceDownloadButtonBy);
            downloadButton.Click();
        }
    }
}
