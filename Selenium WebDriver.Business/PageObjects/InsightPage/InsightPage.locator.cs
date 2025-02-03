using OpenQA.Selenium;

namespace Selenium_WebDriver.Business.PageObjects.InsightPage
{
    public partial class InsightPage
    {
        private static readonly string InsightFirstCarouselLocator = "//div[contains(@class, 'media-content')]";
        private static readonly string InsightCarouselCurrentActiveLocator = "//div[contains(@class, 'media-content')]//div[contains(@class, 'owl-item active')]";

        private static readonly string InsightCarouselCurrentActiveTitleLocator = InsightCarouselCurrentActiveLocator + "//span[@class = 'font-size-60']";
        private static readonly string InsightCarouselReadMoreLocator = InsightCarouselCurrentActiveLocator + "//a[contains(text(), 'Read More')]";

        private readonly By insightFirstCarouselBy = By.XPath(InsightFirstCarouselLocator);
        private readonly By insightCarouselCurrentActiveBy = By.XPath(InsightCarouselCurrentActiveLocator);
        private readonly By insightCarouselCurrentActiveTextBy = By.XPath(InsightCarouselCurrentActiveTitleLocator);
        private readonly By insightCarouselReadMoreBy = By.XPath(InsightCarouselReadMoreLocator);
    }
}
