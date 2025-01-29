using OpenQA.Selenium;
using Selenium_WebDriver.DriverUtils;
using SeleniumExtras.WaitHelpers;
using Task__Selenium_WebDriver.DriverUtils;
using static webdriver_task_3.ExtraClass.ArgumentChecker;

namespace Task__Selenium_WebDriver.PageObjects.CareersPage
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

        public void PerformJobSearch(string keyword, string location)
        {
            CheckArgumentIsNull(keyword, nameof(keyword));
            CheckArgumentIsNull(location, nameof(location));

            var searchFieldElement = this.shortWait.WaitFindElement(this.careerSearchKeywordFieldBy);
            searchFieldElement.SendKeys(keyword);

            var menuIsDeployed = false;
            try
            {
                this.shortWait.WaitElementToBeVisible(this.careerSuggestionsMenuBy);
            }
            catch (Exception)
            {
                menuIsDeployed = true;
            }

            if (menuIsDeployed)
            {
                this.driverManager.ActionPressEscape();
            }

            var locationDropdownElement = this.shortWait.WaitFindElement(this.careerLocationDropdownBy);
            locationDropdownElement.Click();

            var selectedLocationElement = this.SelectLocation(location);
            selectedLocationElement.Click();

            var remoteLabelElement = this.shortWait.WaitUntilElementIsClickable(this.careerRemoteLabelBy);
            remoteLabelElement.Click();

            var searchButtonElement = this.shortWait.WaitFindElement(this.careerSearchButtonBy);
            searchButtonElement.Click();
        }
    }
}