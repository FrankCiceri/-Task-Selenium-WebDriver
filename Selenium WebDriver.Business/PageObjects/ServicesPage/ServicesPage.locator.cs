using OpenQA.Selenium;


namespace Selenium_WebDriver.Business.PageObjects.ServicesPage
{
    public partial class ServicesPage
    {
        private By _serviceTitleBy = By.XPath("//*[contains(@class, 'scaling-of-text-wrapper')]//span[contains(@class, 'font-size-80-33')]//span[contains(@class, 'rte-text-gradient')]");
        private By _ourExpertiseSection = By.XPath("//div[contains(@class, 'section__wrapper')][.//span[contains(text(), 'Our Related Expertise')]]");

        private IWebElement ServiceTitle => _driverContext.GetDriver().FindElement(_serviceTitleBy);

        private IWebElement OurExpertiseSection => _driverContext.GetDriver().FindElement(_ourExpertiseSection);
    }
}
