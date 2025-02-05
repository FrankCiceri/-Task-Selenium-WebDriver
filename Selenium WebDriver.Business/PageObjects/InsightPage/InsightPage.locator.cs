using OpenQA.Selenium;

namespace Selenium_WebDriver.Business.PageObjects.InsightPage
{
    public partial class InsightPage
    {
        private readonly By _currentActiveSlide = By.XPath("//div[contains(@class, 'media-content')]//div[contains(@class, 'owl-item active')]");
        private readonly By _nextCarouselSlideBy = By.XPath("//div[contains(@class, 'media-content')]//button[contains(@class, 'slider__right-arrow')]");
        private readonly By _insightCarouselTitleBy = By.XPath("//div[contains(@class, 'media-content')]//div[contains(@class, 'owl-item active')]//span[@class = 'font-size-60']");
        private readonly By _insightFirstCarouselReadMoreBy = By.XPath("//div[contains(@class, 'media-content')]//div[contains(@class, 'owl-item active')]//a[contains(text(), 'Read More')]");

        private IWebElement CurrentActiveSlide => _driverContext.GetDriver().FindElement(_currentActiveSlide);

        private IWebElement CurrentActiveSlideTitle => _driverContext.GetDriver().FindElement(_insightCarouselTitleBy);

        private IWebElement CurrentActiveSlideReadMoreButton => _driverContext.GetDriver().FindElement(_insightFirstCarouselReadMoreBy);

        private IWebElement FirstCarouselNextSlideButton => _driverContext.GetDriver().FindElement(_nextCarouselSlideBy);

    }
}
