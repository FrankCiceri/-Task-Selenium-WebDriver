using OpenQA.Selenium;

namespace Selenium_WebDriver.Business.PageObjects.AboutPage
{
    public partial class AboutPage
    {
        private static readonly string AboutEpamAtAGlanceLocator = "//span//span[normalize-space() = 'EPAM at a Glance']";
        private static readonly string AboutAtAGlanceDownloadButtonLocator = "//a[contains(@class, 'button-ui-23 btn-focusable') and .//text()[contains(., 'DOWNLOAD')]]";

        private readonly By aboutEpamAtAGlanceBy = By.XPath(AboutEpamAtAGlanceLocator);
        private readonly By aboutAtAGlanceDownloadButtonBy = By.XPath(AboutAtAGlanceDownloadButtonLocator);
    }
}
