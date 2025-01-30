using OpenQA.Selenium;

namespace Selenium_WebDriver.PageObjects
{
    public partial class HeaderPage
    {
        private static readonly string HeaderCareersButtonLocator = "//span/a[text()='Careers']";
        private static readonly string HeaderMagnifierLocator = "header-search__button";
        private static readonly string HeaderSearchPanelLocator = ".header-search__panel.opened";
        private static readonly string HeaderSearchTextfieldLocator = "q";
        private static readonly string HeaderPanelFindButtonLocator = "//button[contains(@class, 'custom-search-button')]";

        private readonly By headerCareersButtonBy = By.XPath(HeaderCareersButtonLocator);
        private readonly By headerMagnifierBy = By.CssSelector(HeaderMagnifierLocator);
        private readonly By headerSearchPanelBy = By.CssSelector(HeaderSearchPanelLocator);
        private readonly By headerSearchTextfieldBy = By.Name(HeaderSearchTextfieldLocator);
        private readonly By headerPanelFindButtonBy = By.XPath(HeaderPanelFindButtonLocator);
    }
}
