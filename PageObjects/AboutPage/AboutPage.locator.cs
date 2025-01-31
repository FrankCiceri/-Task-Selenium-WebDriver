using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.PageObjects.SearchPage
{
    public partial class AboutPage
    {
        private static readonly string AboutEpamAtAGlanceLocator = "//span//span[normalize-space() = 'EPAM at a Glance']";
        private static readonly string AboutAtAGlanceDownloadButtonLocator = "//a[contains(@class, 'button-ui-23 btn-focusable') and .//text()[contains(., 'DOWNLOAD')]]";

        private readonly By AboutEpamAtAGlanceBy = By.XPath(AboutEpamAtAGlanceLocator);
        private readonly By AboutAtAGlanceDownloadButtonBy = By.XPath(AboutAtAGlanceDownloadButtonLocator);

    }
}
