using OpenQA.Selenium;
using Selenium_WebDriver.DriverUtils;
using SeleniumExtras.WaitHelpers;
using Selenium_WebDriver.DriverUtils;
using static  Selenium_WebDriver.ExtraClass.ArgumentChecker;

namespace Selenium_WebDriver.PageObjects.CareersPage
{
    public partial class CareerPage
    {
        public CareerPage(DriverManager driverManager)
        {
            if (driverManager is null)
            {
                throw new ArgumentNullException(nameof(driverManager));
            }

            this.driverManager = driverManager;
            this.shortWait = driverManager.ShortWait;
            this.longWait = driverManager.LongWait;
        }

        public void EnterSearchKeyword(string keyword)
        {
            CheckArgumentIsNull(keyword, nameof(keyword));
            var searchFieldElement = this.shortWait.WaitFindElement(this.careerSearchKeywordFieldBy);
            searchFieldElement.SendKeys(keyword);
            this.CloseSuggestionsMenuIfVisible();
        }

        public void SelectLocationFromDropdown(string location)
        {
            CheckArgumentIsNull(location, nameof(location));

            var locationDropdownElement = this.shortWait.WaitFindElement(this.careerLocationDropdownBy);
            locationDropdownElement.Click();

            var selectedLocationElement = this.SelectLocation(location);
            selectedLocationElement.Click();
        }

        public void ClickRemoteLabel()
        {
            var remoteLabelElement = this.shortWait.WaitUntilElementIsClickable(this.careerRemoteLabelBy);
            remoteLabelElement.Click();
        }

        public void ClickSearchButton()
        {
            var searchButtonElement = this.shortWait.WaitFindElement(this.careerSearchButtonBy);
            searchButtonElement.Click();
        }

        public void SortJobsByDate()
        {
            var dateSortingButton = this.longWait.WaitUntilElementIsClickable(this.careerDateFilterButtonBy);
            this.driverManager.GoToElementAndClick(dateSortingButton);

            this.shortWait.WaitUntilAttributeContains(this.careerPreloaderBy, "style", "display: block;");
            this.shortWait.WaitUntilAttributeContains(this.careerPreloaderBy, "style", "display: none;");
        }

        public void ApplyToFirstJob()
        {
            var firstElement = this.longWait.WaitUntilElementIsClickable(this.careerFirstResultBy);
            this.driverManager.GoToElement(firstElement);

            var applyButton = this.longWait.WaitUntilElementIsClickable(this.careerFirstResultApplyBy);
            this.driverManager.GoToElementAndClick(applyButton);
        }
    }
}