using OpenQA.Selenium;

namespace Selenium_WebDriver.Business.PageObjects.AboutPage
{
    public partial class AboutPage
    {
        private readonly By _aboutEpamAtAGlanceBy = By.XPath("//span//span[normalize-space() = 'EPAM at a Glance']");
        private readonly By _aboutAtAGlanceDownloadButtonBy = By.XPath("//a[contains(@class, 'button-ui-23 btn-focusable') and .//text()[contains(., 'DOWNLOAD')]]");

        private IWebElement AboutEpamAtAGlanceText => _driverContext.GetDriver().FindElement(_aboutEpamAtAGlanceBy);

        private IWebElement AboutAtAGlanceDownloadButton => _driverContext.GetDriver().FindElement(_aboutAtAGlanceDownloadButtonBy);
    }
}
