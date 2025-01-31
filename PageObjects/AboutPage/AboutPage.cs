using OpenQA.Selenium;
using Selenium_WebDriver.DriverUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.SearchPage
{
    public partial class AboutPage
    {
        public AboutPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }

        public void ScrollToAtAGlance()
        {
            var atAGlanceText = this.longWait.WaitUntilElementExists(this.AboutEpamAtAGlanceBy);
            this.driverManager.ScrollToElement(atAGlanceText);
        }

        public void ClickDownloadButton()
        {
            var downloadButton = this.longWait.WaitUntilElementIsClickable(this.AboutAtAGlanceDownloadButtonBy);
            downloadButton.Click();
        }
    }
}
