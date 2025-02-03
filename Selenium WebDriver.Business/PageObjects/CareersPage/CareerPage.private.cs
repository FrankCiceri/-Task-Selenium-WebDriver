using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.CareersPage
{
    public partial class CareerPage
    {
        private readonly IDriverContext driverContext;

        private IWebElement SelectLocation(string location)
        {
            string locationLocator = $"//li[contains(text(), '{location}')]";
            By locationBy = By.XPath(locationLocator);
            return this.driverContext.ShortWait.WaitFindElement(locationBy);
        }

        private void CloseSuggestionsMenuIfVisible()
        {
            if (this.driverContext.IsElementVisible(this.careerSuggestionsMenuBy))
            {
                this.driverContext.ActionPressEscape();
            }
        }
    }
}
