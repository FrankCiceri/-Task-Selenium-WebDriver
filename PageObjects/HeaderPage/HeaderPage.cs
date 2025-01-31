using OpenQA.Selenium.Interactions;
using Selenium_WebDriver.DriverUtils;

namespace Selenium_WebDriver.PageObjects
{
    public partial class HeaderPage
    {
        public HeaderPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }

        public void ClickCareersLink()
        {
            var careersButton = this.longWait.WaitUntilElementIsClickable(this.headerCareersButtonBy);
            careersButton.Click();
        }

        public void ClickAboutLink()
        {
            var aboutButton = this.longWait.WaitUntilElementIsClickable(this.headerAboutButtonBy);
            aboutButton.Click();
        }

        public void ClickHeaderMagnifier()
        {
            var magnifierElement = this.longWait.WaitUntilElementIsClickable(this.headerMagnifierBy);
            magnifierElement.Click();
        }

        public void WaitHeaderSearchPanelToDeploy()
        {
            this.longWait.WaitUntilElementExists(this.headerSearchPanelBy);
        }

        public void EnterHeaderPanelSearch(string searchString)
        {
            var searchField = this.shortWait.WaitFindElement(this.headerSearchTextfieldBy);
            this.driverManager.GoToElementAndClick(searchField);

            new Actions(this.driverManager.GetDriver())
                .Pause(TimeSpan.FromSeconds(1))
                .SendKeys(searchString)
                .Perform();
        }

        public void ClickHeaderPanelSearchButton()
        {
            var searchButton = this.shortWait.WaitUntilElementIsClickable(this.headerPanelFindButtonBy);
            searchButton.Click();
        }
    }
}
