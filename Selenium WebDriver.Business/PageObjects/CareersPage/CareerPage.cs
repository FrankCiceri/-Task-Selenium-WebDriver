using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using static  Selenium_WebDriver.Core.ExtraClass.ArgumentChecker;
using Selenium_WebDriver.Core.Interfaces;
using Selenium_WebDriver.Core.Core;

namespace Selenium_WebDriver.Business.PageObjects.CareersPage
{
    public partial class CareerPage
    {
        public CareerPage(IDriverContext driverContext)
        {
            if (driverContext is null)
            {
                throw new ArgumentNullException(nameof(driverContext));
            }

            this.driverContext = driverContext;
        }

        public void EnterSearchKeyword(string keyword)
        {
            CheckArgumentIsNull(keyword, nameof(keyword));
            var searchFieldElement = this.driverContext.ShortWait.WaitFindElement(this.careerSearchKeywordFieldBy);
            searchFieldElement.SendKeys(keyword);
            this.CloseSuggestionsMenuIfVisible();
        }

        public void SelectLocationFromDropdown(string location)
        {
            CheckArgumentIsNull(location, nameof(location));

            var locationDropdownElement = this.driverContext.ShortWait.WaitFindElement(this.careerLocationDropdownBy);
            locationDropdownElement.Click();

            var selectedLocationElement = this.SelectLocation(location);
            selectedLocationElement.Click();
        }

        public void ClickRemoteLabel()
        {
            var remoteLabelElement = this.driverContext.ShortWait.WaitUntilElementIsClickable(this.careerRemoteLabelBy);
            remoteLabelElement.Click();
        }

        public void ClickSearchButton()
        {
            var searchButtonElement = this.driverContext.ShortWait.WaitFindElement(this.careerSearchButtonBy);
            searchButtonElement.Click();
        }

        public void SortJobsByDate()
        {
            var dateSortingButton = this.driverContext.LongWait.WaitUntilElementIsClickable(this.careerDateFilterButtonBy);
            this.driverContext.GoToElementAndClick(dateSortingButton);

            this.driverContext.ShortWait.WaitUntilAttributeContains(this.careerPreloaderBy, "style", "display: block;");
            this.driverContext.ShortWait.WaitUntilAttributeContains(this.careerPreloaderBy, "style", "display: none;");
        }

        public void ApplyToFirstJob()
        {
            var firstElement = this.driverContext.LongWait.WaitUntilElementIsClickable(this.careerFirstResultBy);
            this.driverContext.GoToElement(firstElement);

            var applyButton = this.driverContext.LongWait.WaitUntilElementIsClickable(this.careerFirstResultApplyBy);
            this.driverContext.GoToElementAndClick(applyButton);
        }
    }
}