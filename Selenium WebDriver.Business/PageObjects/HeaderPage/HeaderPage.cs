using OpenQA.Selenium.Interactions;
using Selenium_WebDriver.Core.Core;
using Selenium_WebDriver.Core.Interfaces;

namespace Selenium_WebDriver.Business.PageObjects.HeaderPage
{
    public partial class HeaderPage
    {
        public HeaderPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this.driverContext = driverContext;
        }

        public void ClickCareersLink()
        {
            var careersButton = this.driverContext.LongWait.WaitUntilElementIsClickable(this.headerCareersButtonBy);
            careersButton.Click();
        }

        public void ClickAboutLink()
        {
            var aboutButton = this.driverContext.LongWait.WaitUntilElementIsClickable(this.headerAboutButtonBy);
            aboutButton.Click();
        }

        public void ClickInsightsLink()
        {
            var insightsButton = this.driverContext.LongWait.WaitUntilElementIsClickable(this.headerInsightsButtonBy);
            insightsButton.Click();
        }

        public void ClickHeaderMagnifier()
        {
            var magnifierElement = this.driverContext.LongWait.WaitUntilElementIsClickable(this.headerMagnifierBy);
            magnifierElement.Click();
        }

        public void WaitHeaderSearchPanelToDeploy()
        {
            this.driverContext.LongWait.WaitUntilElementExists(this.headerSearchPanelBy);
        }

        public void EnterHeaderPanelSearch(string searchString)
        {
            var searchField = this.driverContext.ShortWait.WaitFindElement(this.headerSearchTextfieldBy);
            this.driverContext.GoToElementAndClick(searchField);

            new Actions(this.driverContext.GetDriver())
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(searchString)
                .Perform();
        }

        public void ClickHeaderPanelSearchButton()
        {
            var searchButton = this.driverContext.ShortWait.WaitUntilElementIsClickable(this.headerPanelFindButtonBy);
            searchButton.Click();
        }
    }
}
