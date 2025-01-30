using OpenQA.Selenium;

namespace Selenium_WebDriver.PageObjects
{
    public partial class HeaderPage
    {
        private static readonly string HeaderCareersButtonLocator = "//span/a[text()='Careers']";

        private readonly By headerCareersButtonBy = By.XPath(HeaderCareersButtonLocator);
    }
}
