using OpenQA.Selenium;

namespace Selenium_WebDriver.Business.PageObjects.HeaderPage
{
    public partial class HeaderPage
    {
        private readonly By _headerCareersButtonBy = By.XPath("//span/a[text()='Careers']");
        private readonly By _headerAboutButtonBy = By.XPath("//span/a[text()='About']");
        private readonly By _headerInsightsButtonBy = By.XPath("//span/a[text()='Insights']");
        private readonly By _headerServicesButton = By.XPath("//span/a[text()='Services']");
        private readonly By _headerServicesDropdownItems = By.XPath("//span/a[text()='Services']//following::li[contains(@class,'sub-item')]//a[contains(@href, '/services/')]");
        private readonly By _headerMagnifierBy = By.CssSelector(".header-search__button");
        private readonly By _headerSearchPanelBy = By.CssSelector(".header-search__panel.opened");
        private readonly By _headerSearchTextfieldBy = By.Name("q");
        private readonly By _headerPanelFindButtonBy = By.XPath("//button[contains(@class, 'custom-search-button')]");

        private IWebElement CareersButton => _driverContext.GetDriver().FindElement(_headerCareersButtonBy);

        private IWebElement AboutButton => _driverContext.GetDriver().FindElement(_headerAboutButtonBy);

        private IWebElement InsightsButton => _driverContext.GetDriver().FindElement(_headerInsightsButtonBy);

        private IWebElement ServicesButton => _driverContext.GetDriver().FindElement(_headerServicesButton);

        private IEnumerable<IWebElement> ServicesDropdownItems => _driverContext.GetDriver().FindElements(_headerServicesDropdownItems);

        private IWebElement MagnifierButton => _driverContext.GetDriver().FindElement(_headerMagnifierBy);

        private IWebElement SearchTextField => _driverContext.GetDriver().FindElement(_headerSearchTextfieldBy);

        private IWebElement FindButton => _driverContext.GetDriver().FindElement(_headerPanelFindButtonBy);
    }
}
