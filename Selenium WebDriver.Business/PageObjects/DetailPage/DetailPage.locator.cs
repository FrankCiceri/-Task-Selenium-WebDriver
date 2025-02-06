using OpenQA.Selenium;

namespace Selenium_WebDriver.Business.PageObjects.DetailPage
{
    public partial class DetailPage
    {
        private readonly By _detailHeaderTitleBy = By.XPath("//*[contains(@class, 'scaling-of-text-wrapper')]//span[contains(@class, 'font-size-80-33')]//span[contains(@class, 'museo-sans-light')]");

        private IWebElement HeaderTitle => _driverContext.GetDriver().FindElement(_detailHeaderTitleBy);
    }
}
